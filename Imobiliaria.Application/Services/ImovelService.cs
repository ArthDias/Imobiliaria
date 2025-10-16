using Imobiliaria.Application.Interfaces;
using Imobiliaria.Application.Requests.Imovel;
using Imobiliaria.Domain.Common;
using Imobiliaria.Domain.DTOs;
using Imobiliaria.Domain.Entities;
using Imobiliaria.Domain.Enums;
using Imobiliaria.Domain.Interfaces;

namespace Imobiliaria.Application.Services;

public class ImovelService(IImovelRepository imovelRepository, IViaCepService viaCepService) : IImovelService
{
    private readonly IImovelRepository _imovelRepository = imovelRepository;
    private readonly IViaCepService _viaCepService = viaCepService;

    public async Task<Result<ImovelDTO>> CriarImovelAsync(CriarImovelRequest request)
    {
        if (request == null)
        {
            return Result.Failure<ImovelDTO>(Error.BadRequest("O objeto do request está vazio."));
        }

        var cepResult = await _viaCepService.BuscarEnderecoPorCepAsync(request.Cep);

        if (cepResult.IsFailure)
        {
            return Result.Failure<ImovelDTO>(cepResult.Error);
        }

        var endereco = cepResult.Value;

        var imovel = MapImovel(request, endereco);
        var resultCriar = await _imovelRepository.CriarImovelAsync(imovel);
        if (resultCriar.IsFailure)
        {
            return Result.Failure<ImovelDTO>(resultCriar.Error);
        }
        var imovelDTO = MapImovelDTO(imovel);

        return Result.Success(imovelDTO);
    }

    public async Task<Result<Imovel>> BuscarImovelByIdAsync(int id)
    {
        var resultGetByIdToUpdate = await _imovelRepository.BuscarImovelByIdAsync(id);
        if (resultGetByIdToUpdate.IsFailure)
            return Result.Failure<Imovel>(resultGetByIdToUpdate.Error);

        if (resultGetByIdToUpdate.Value == null)
            return Result.Failure<Imovel>(Error.BadRequest("Imóvel inexistente"));

        return Result.Success(resultGetByIdToUpdate.Value);
    }
    public async Task<Result<List<Imovel>>> BuscarTodosAsync()
    {
        var resultGetByIdToUpdate = await _imovelRepository.BuscarTodosAsync();
        if (resultGetByIdToUpdate.IsFailure)
            return Result.Failure<List<Imovel>> (resultGetByIdToUpdate.Error);

        if (resultGetByIdToUpdate.Value == null)
            return Result.Failure<List<Imovel>> (Error.BadRequest("Nenhum imóvel cadastrado"));

        return Result.Success(resultGetByIdToUpdate.Value);
    }
    public async Task<Result> AtualizarAsync(int id, AtualizarImovelRequest imovel)
    {
        var resultGetByIdToUpdate = await _imovelRepository.BuscarImovelByIdAsync(id);
        if (resultGetByIdToUpdate.IsFailure)
            return Result.Failure(resultGetByIdToUpdate.Error);

        if (resultGetByIdToUpdate.Value == null)
            return Result.Failure(Error.BadRequest("Imóvel inexistente"));

        if (imovel == null)
        {
            return Result.Failure(Error.BadRequest("O objeto do request está vazio."));
        }

        Imovel imovelToUpdate = resultGetByIdToUpdate.Value;
        var imovelAtualizado = imovelToUpdate;
        if(imovel.Descricao != null) imovelAtualizado.Descricao = imovel.Descricao;
        if(imovel.Numero != null) imovelAtualizado.Numero = imovel.Numero;
        if(imovel.ValorAluguel != null) imovelAtualizado.ValorAluguel = (decimal)imovel.ValorAluguel;
        if(imovel.Cep != null) 
        {
            var cepResult = await _viaCepService.BuscarEnderecoPorCepAsync(imovel.Cep);
            if (cepResult.IsFailure)
            {
                return Result.Failure(cepResult.Error);
            }
            var endereco = cepResult.Value;
            imovelAtualizado.Cep = endereco.Cep;
            imovelAtualizado.Logradouro = endereco.Logradouro;
            imovelAtualizado.Cidade = endereco.Localidade;
            imovelAtualizado.Estado = endereco.Uf;
        }
        if(imovel.Numero != null) imovelAtualizado.Numero = imovel.Numero;
        if(imovel.Status != null) imovelAtualizado.Status = (EStatusImovel)imovel.Status;


        return await _imovelRepository.AtualizarAsync(id, imovelAtualizado);
    }
    public async Task<Result> DeletarImovelAsync(int id)
    {
        var imovelResult = await _imovelRepository.BuscarImovelByIdAsync(id);
        if (imovelResult.IsFailure)
            return Result.Failure<ImovelDTO>(imovelResult.Error);

        if (imovelResult.Value == null)
            return Result.Failure<ImovelDTO>(Error.BadRequest("Imóvel inexistente"));

        return await _imovelRepository.DeletarImovelAsync(id);
    }
    private static Imovel MapImovel(CriarImovelRequest request, ViaCepDTO endereco)
    {
        return new Imovel()
        {
            Descricao = request.Descricao,
            Cep = endereco.Cep,
            Logradouro = endereco.Logradouro,
            Numero = request.Numero,
            Cidade = endereco.Localidade,
            Estado = endereco.Uf,
            ValorAluguel = request.ValorAluguel,
            Status = EStatusImovel.Vago,
        };
    }
    private static ImovelDTO MapImovelDTO(Imovel imovel)
    {
        return new ImovelDTO()
        {
            Id = imovel.Id,
            Descricao = imovel.Descricao,
            Cep = imovel.Cep,
            Logradouro = imovel.Logradouro,
            Numero = imovel.Numero,
            Cidade = imovel.Cidade,
            Estado = imovel.Estado,
            ValorAluguel = imovel.ValorAluguel,
            Status = imovel.Status
        };
    }

}

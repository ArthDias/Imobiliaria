using Imobiliaria.Application.Requests.Imovel;
using Imobiliaria.Domain.Common;
using Imobiliaria.Domain.DTOs;
using Imobiliaria.Domain.DTOs.Imoveis;
using Imobiliaria.Domain.Entities;
using Imobiliaria.Domain.Interfaces;

namespace Imobiliaria.Application.Services;

public class ImovelService(IImovelRepository imovelRepository) : IImovelService
{
    private readonly IImovelRepository _imovelRepository = imovelRepository;

    public async Task<Result<ImovelDTO>> CriarImovelAsync(CriarImovelRequest request)
    {
        if (request == null)
        {
            return Result.Failure<ImovelDTO>(Error.BadRequest("O objeto do request está vazio."));
        }
        var imovel = MapImovel(request);
        var resultCriar = await _imovelRepository.CriarImovelAsync(imovel);
        if (resultCriar.IsFailure)
        {
            return Result.Failure<ImovelDTO>(resultCriar.Error);
        }
        var imovelDTO = MapImovelDTO(imovel);

        return Result.Success(imovelDTO);
    }

    public async Task<Result<Imovel?>> BuscarImovelByIdAsync(int id)
    {
        return await _imovelRepository.BuscarImovelByIdAsync(id);
    }
    public async Task<Result<List<Imovel>>> BuscarTodosAsync()
    {
        return await _imovelRepository.BuscarTodosAsync();
    }
    public async Task<Result> AtualizarAsync(int id, AtualizarImovelDto imovel)
    {
        return await _imovelRepository.AtualizarAsync(id, imovel);
    }
    public async Task<Result> DeletarImovelAsync(int id)
    {
        return await _imovelRepository.DeletarImovelAsync(id);
    }

    private static Imovel MapImovel(CriarImovelRequest request)
    {
        return new Imovel()
        {
            Descricao = request.Descricao,
            ValorAluguel = request.ValorAluguel,
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
        };
    }

}

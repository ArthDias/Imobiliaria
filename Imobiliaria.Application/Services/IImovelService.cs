using Imobiliaria.Domain.Common;
using Imobiliaria.Domain.DTOs.Imoveis;
using Imobiliaria.Domain.Entities;
using Imobiliaria.Domain.Interfaces;

namespace Imobiliaria.Application.Services;

public class ImovelService : IImovelService
{
    private readonly IImovelRepository _repository;

    public ImovelService(IImovelRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Imovel>> CriarImovelAsync(CriarImovelDto dto)
    {
        var imovel = new Imovel();
        return await _repository.CriarImovelAsync(imovel);
    }

    public async Task<Result<Imovel?>> BuscarImovelByIdAsync(int id)
    {
        return await _repository.BuscarImovelByIdAsync(id);
    }
    public async Task<Result<List<Imovel>>> BuscarTodosAsync()
    {
        return await _repository.BuscarTodosAsync();
    }
    public async Task<Result> AtualizarAsync(int id, AtualizarImovelDto imovel)
    {
        return await _repository.AtualizarAsync(id, imovel);
    }
    public async Task<Result> DeletarImovelAsync(int id)
    {
        return await _repository.DeletarImovelAsync(id);
    }
}

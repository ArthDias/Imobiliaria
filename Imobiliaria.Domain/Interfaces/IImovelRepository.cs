using Imobiliaria.Domain.Common;
using Imobiliaria.Domain.DTOs.Imoveis;
using Imobiliaria.Domain.Entities;

namespace Imobiliaria.Domain.Interfaces;

public interface IImovelRepository
{
    Task<Result<List<Imovel>>> BuscarTodosAsync();
    Task<Result<Imovel?>> BuscarImovelByIdAsync(int id);
    Task<Result<Imovel>> CriarImovelAsync(Imovel imovel);
    Task<Result> AtualizarAsync(int id, AtualizarImovelDto imovel);
    Task<Result> DeletarImovelAsync(int id);
}
using Imobiliaria.Domain.Entities;
using Imobiliaria.Domain.Common;
using Imobiliaria.Domain.DTOs.Imoveis;

namespace Imobiliaria.Application.Services;

public interface IImovelService
{
    Task<Result<Imovel>> CriarImovelAsync(CriarImovelDto dto);
    Task<Result<Imovel?>> BuscarImovelByIdAsync(int id);
    Task<Result<List<Imovel>>> BuscarTodosAsync();
    Task<Result> AtualizarAsync( int id, AtualizarImovelDto imovel);
    Task<Result> DeletarImovelAsync(int id);
}

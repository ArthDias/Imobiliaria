using Imobiliaria.Application.Requests.Imovel;
using Imobiliaria.Domain.Common;
using Imobiliaria.Domain.DTOs;
using Imobiliaria.Domain.Entities;

namespace Imobiliaria.Application.Services;

public interface IImovelService
{
    Task<Result<ImovelDTO>> CriarImovelAsync(CriarImovelRequest dto);
    Task<Result<Imovel>> BuscarImovelByIdAsync(int id);
    Task<Result<List<Imovel>>> BuscarTodosAsync();
    Task<Result> AtualizarAsync( int id, AtualizarImovelRequest imovel);
    Task<Result> DeletarImovelAsync(int id);
}

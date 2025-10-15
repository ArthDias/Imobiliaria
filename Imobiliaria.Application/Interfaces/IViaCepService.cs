using Imobiliaria.Domain.Common;
using Imobiliaria.Domain.DTOs;

namespace Imobiliaria.Application.Interfaces;

public interface IViaCepService
{
    Task<Result<ViaCepDTO>> BuscarEnderecoPorCepAsync(string cep);
}

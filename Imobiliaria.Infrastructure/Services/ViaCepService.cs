using Imobiliaria.Application.Interfaces;
using Imobiliaria.Domain.Common;
using Imobiliaria.Domain.DTOs;
using System.Text.Json;

namespace Imobiliaria.Infrastructure.Services;
public class ViaCepService : IViaCepService
{
    private readonly HttpClient _http;
    public ViaCepService(HttpClient http) => _http = http;

    public async Task<Result<ViaCepDTO>> BuscarEnderecoPorCepAsync(string cep)
    {
        cep = LimparCep(cep);

        if (cep.Length != 8)
        {
            return Result.Failure<ViaCepDTO>(Error.BadRequest("CEP Inválido. Deve conter apenas números."));
        }

        var response = await _http.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

        if (!response.IsSuccessStatusCode) return Result.Failure<ViaCepDTO>(Error.BadRequest("Erro no serviço de cep tercerizado."));
        var json = await response.Content.ReadAsStringAsync();
        var serializer = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var content = JsonSerializer.Deserialize<ViaCepDTO>(json, serializer);
        if(content == null)
        {
            return Result.Failure<ViaCepDTO>(Error.BadRequest("CEP não retornou endereço."));
        }
        content.Cep = LimparCep(content.Cep);
        return Result.Success<ViaCepDTO>(content);
    }
    public string LimparCep(string cep)
    {
        return new string(cep.Where(char.IsDigit).ToArray());
    }
}
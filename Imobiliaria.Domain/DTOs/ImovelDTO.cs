using Imobiliaria.Domain.Enums;

namespace Imobiliaria.Domain.DTOs;
public class ImovelDTO
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    public string Logradouro { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public decimal ValorAluguel { get; set; }
    public EStatusImovel Status { get; set; }
}
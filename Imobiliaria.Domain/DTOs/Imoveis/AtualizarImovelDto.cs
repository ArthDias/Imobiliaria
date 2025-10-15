namespace Imobiliaria.Domain.DTOs.Imoveis;

public class AtualizarImovelDto
{
    public string? Descricao { get; set; }
    public string? Cep { get; set; }
    public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public decimal? ValorAluguel { get; set; }
    public string? Status { get; set; }
}
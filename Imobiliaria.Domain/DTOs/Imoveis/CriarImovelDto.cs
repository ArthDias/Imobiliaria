namespace Imobiliaria.Domain.DTOs.Imoveis;

public class CriarImovelDto
{
    public string Descricao { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    public string Logradouro { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public decimal ValorAluguel { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Imobiliaria.Application.Requests.Imovel;

public class CriarImovelRequest
{
    [Required]
    public string Descricao { get; set; } = string.Empty;
    [Required]
    public string Cep { get; set; } = string.Empty;
    [Required]
    public string Numero { get; set; } = string.Empty;
    [Required]
    public decimal ValorAluguel { get; set; }
}

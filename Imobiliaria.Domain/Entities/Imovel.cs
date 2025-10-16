using Imobiliaria.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imobiliaria.Domain.Entities;

[Table("IMOVEIS")]
public class Imovel
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;

    [Required]
    [StringLength(8, MinimumLength = 8)]
    public string Cep { get; set; } = string.Empty;

    public string Logradouro { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;

    [Range(0, double.MaxValue)]
    public decimal ValorAluguel { get; set; }

    public EStatusImovel Status { get; set; }
}

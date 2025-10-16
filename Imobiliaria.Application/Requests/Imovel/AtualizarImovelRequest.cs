using Imobiliaria.Domain.Enums;

namespace Imobiliaria.Application.Requests.Imovel;
public class AtualizarImovelRequest
{
    public string? Descricao { get; set; }
    public string? Cep { get; set; }
    public string? Numero { get; set; }
    public decimal? ValorAluguel { get; set; }
    public EStatusImovel? Status { get; set; }
}
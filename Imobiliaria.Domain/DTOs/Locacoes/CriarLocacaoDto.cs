namespace Imobiliaria.Domain.DTOs.Locacoes;
public class CriarLocacaoDto
{
    public int ImovelId { get; set; }
    public int ClienteId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
}
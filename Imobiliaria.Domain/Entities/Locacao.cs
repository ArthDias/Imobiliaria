namespace Imobiliaria.Domain.Entities;

public class Locacao
{
    public int Id { get; set; }
    public int ImovelId { get; set; }
    public int ClienteId { get; set; }
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public decimal ValorTotal { get; set; }

}

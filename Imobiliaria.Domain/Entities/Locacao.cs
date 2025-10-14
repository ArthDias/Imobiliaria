using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imobiliaria.Domain.Entities
{
    internal class Locacao
    {
        public int Id { get; set; }
        public int ImovelId { get; set; }
        public int ClienteId { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public decimal ValorTotal { get; set; }

    }
}

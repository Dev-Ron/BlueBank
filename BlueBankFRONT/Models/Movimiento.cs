using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBankFRONT.Models
{
    public class Movimiento : BaseEntity
    {
        public Cuenta Cuenta { get; set; }
        public decimal Valor { get; set; }
        public DateTime FechaMovimiento { get; set; }
    }
}

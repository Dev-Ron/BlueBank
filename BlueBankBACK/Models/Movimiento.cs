using System;

namespace BlueBankBACK.Models
{
    public class Movimiento : BaseEntity
    {
        public Cuenta Cuenta { get; set; }
        public decimal Valor { get; set; }
        public DateTime FechaMovimiento { get; set; }
    }
}

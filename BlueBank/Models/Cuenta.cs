using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBankAPI.Models
{
    public class Cuenta : BaseEntity
    {
        public Persona Persona { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal Valor { get; set; }
    }
}

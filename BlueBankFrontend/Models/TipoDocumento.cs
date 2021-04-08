using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBankFrontend.Models
{
    public class TipoDocumento : BaseEntity
    {
        public string Tipo { get; set; }
    }
}

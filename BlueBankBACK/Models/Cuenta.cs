namespace BlueBankBACK.Models
{
    public class Cuenta : BaseEntity
    {
        public Persona Persona { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal Valor { get; set; }
    }
}

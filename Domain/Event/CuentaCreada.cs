
using SharedKernel.Core;

namespace Domain.Event
{
    public record CuentaCreada : DomainEvent
    {
        public Guid UsuarioId { get; set; }
        public string NombreCuenta { get; set; }
        public decimal SaldoInicial { get; set; }


        public CuentaCreada( Guid usuarioId, string nombreCuenta, decimal saldoInicial, DateTime occuredOn) : base(occuredOn)
        {
            UsuarioId = usuarioId;
            NombreCuenta = nombreCuenta;
            SaldoInicial = saldoInicial;
        }
    }


}

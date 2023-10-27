using Domain.Model.Movimientos;
using SharedKernel.Core;

namespace Domain.Event
{
    public record SaldoDeCuentaActualizado : DomainEvent
    {
        public Guid CuentaId { get; set; }
        public TipoMovimiento Tipo { get; set; }
        public decimal Monto { get; set; }

        public SaldoDeCuentaActualizado(Guid cuentaId, decimal monto, TipoMovimiento tipo, DateTime occuredOn) : base(occuredOn)
        {
            CuentaId = cuentaId;
            Monto = monto;
            Tipo = tipo;
        }
    }


}

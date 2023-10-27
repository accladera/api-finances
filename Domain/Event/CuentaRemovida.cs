using SharedKernel.Core;

namespace Domain.Event
{
   

    public record CuentaRemovida : DomainEvent
    {
        public Guid CuentaId { get; set; }


        public CuentaRemovida(Guid cuentaId, DateTime occuredOn) : base(occuredOn)
        {

            CuentaId = cuentaId;
        }
    }
    }
    
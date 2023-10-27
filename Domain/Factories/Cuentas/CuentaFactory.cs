
using Domain.Event;
using Domain.Model.Cuentas;

namespace Domain.Factories.Cuentas
{
    public class CuentaFactory : ICuentaFactory
    {
        public Cuenta Create(Guid usuarioId, string nombre, decimal saldo)
        {
            var obj = new Cuenta(usuarioId, nombre, saldo);
            //var domainEvent = new CuentaCreada(obj.Id, obj.Nombre,obj.Saldo, DateTime.Now);
            //obj.AddDomainEvent(domainEvent);
            return obj;

        }

    }
}

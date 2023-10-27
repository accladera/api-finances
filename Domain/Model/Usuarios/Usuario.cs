using Domain.Event;
using Domain.Model.Cuentas;
using Domain.Model.Movimientos;
using Domain.ValueObjects;
using SharedKernel.Core;
using System.Threading;

namespace Domain.Model.Usuarios
{
    public class Usuario : AggregateRoot<Guid>
    {
        public EmailValue Email { get; private set; }
        public UserPasswordValue Password { get; private set; }
        public decimal SaldoTotal { get; private set; }

        protected Usuario() { }

         public Usuario( string email , string password)
        {
            Email = email;
            Password = password;
            SaldoTotal = 0;
            Id = Guid.NewGuid();
           
        }

        public void EditarSaldo(decimal saldo)
        {
            SaldoTotal = saldo;
        }
        public bool ValidarCredenciales(string email, string password)
        {
            return (Email==email && Password==password);
        }
        public void IngresarValoresPorDefecto(Guid usuarioId)
        {
            AddDomainEvent(new UsuarioCreado(usuarioId, DateTime.Now));
        }
      
    }
}

using Domain.Event;
using SharedKernel.Core;
using SharedKernel.ValueObjects;

namespace Domain.Model.Categorias
{
    public class Categoria : AggregateRoot<Guid>
    {
        public NombreGeneralValue Nombre { get; private set; }
       // public bool Estado { get; private set; }
        public GuidVerificadoValue UsuarioId { get; private set; }
        
        public Categoria(string nombre, Guid usuarioId)
        {
            UsuarioId = usuarioId;
            Nombre = nombre;
        //    Estado = true;
            Id = Guid.NewGuid();

        }
        protected Categoria() { }
        public void EditarCategoria(string nombre)
        {
            Nombre = nombre;
        }

        public void EliminarCategoria()
        {
         //   Estado = false;
            AddDomainEvent(new CategoriaRemovida(Id, DateTime.Now));

        }

       

    }
}

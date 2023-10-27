
using SharedKernel.Core;

namespace Domain.Event
{
    
    public record CategoriaRemovida : DomainEvent
    {
    public Guid CategoriaId { get; set; }


    public CategoriaRemovida(Guid categoriaId, DateTime occuredOn) : base(occuredOn)
    {
      
        CategoriaId = categoriaId;
    }
}
}

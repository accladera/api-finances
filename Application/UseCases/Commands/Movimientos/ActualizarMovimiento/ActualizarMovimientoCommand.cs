
using Domain.Model.Movimientos;
using MediatR;

namespace Application.UseCases.Commands.Movimientos.ActualizarMovimiento
{
    public class ActualizarMovimientoCommand : IRequest<Guid>
    {

        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public Guid CategoriaId { get; set; }
        public decimal Tipo { get; set; }
        public decimal Monto { get; set; }
    }
}

using Domain.Model.Categorias;
using Domain.Model.Movimientos;
using Domain.ValueObjects;

namespace TestDomain
{
    public class TestMovimiento
    {
        [Fact]
        public void Creacion_Should_Correct()
        {
            //Arrange or SetUp
            var tipo = 1;
            var usuarioId = Guid.NewGuid();
            var categoriaId = Guid.NewGuid();
            var cuentaId = Guid.NewGuid();
            var fecha = new DateTime();
            var descripcion = new DescripcionValue("Nuevo");
            var monto = new MontoValue(4564);


            //Act
            Movimiento obj = new Movimiento(TipoMovimiento.Ingreso, fecha, descripcion, monto, usuarioId, cuentaId, categoriaId);
            //Assert or Verify
            Assert.NotNull(obj.Tipo);
            Assert.NotNull(obj.UsuarioId);
            Assert.NotNull(obj.CategoriaId);
            Assert.NotNull(obj.CuentaId);
            Assert.NotNull(obj.Fecha);
            Assert.NotNull(obj.Id);
        }


    }
}

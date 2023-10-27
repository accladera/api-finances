using Domain.Model.Categorias;
using SharedKernel.Core;

namespace TestDomain
{

    public class TestCategoria
    {
        [Fact]
        public void Creacion_Should_Correct()
        {
            //Arrange or SetUp
            var nombre = "Comida";
            var usuarioId = Guid.NewGuid();
            //Act
            Categoria obj = new Categoria(nombre, usuarioId);
            //Assert or Verify
            Assert.NotNull(obj.Nombre);
            Assert.Equal(nombre, obj.Nombre);
            Assert.NotNull(obj.Id);
        }



        [Fact]
        public void Creacion_Should_Fail()
        {
            //Arrange or SetUp
            var nombre = "Categoría de comida preferida comprada en el supermercado";
            var usuarioId = Guid.NewGuid();
            Assert.Throws<BussinessRuleValidationException>(() => new Categoria(nombre, usuarioId));
        }


    }
}
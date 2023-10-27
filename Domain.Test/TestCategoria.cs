
using Domain.Model.Categorias;
using Shared.Core;

namespace Domain.Test
{
    
    public class TestCategoria
    {
        [Fact]
        public void Creacion_Should_Correct()
        {
            //Arrange or SetUp
            var nombre = "Comida";
            //Act
            Categoria obj= new Categoria(nombre);
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
            Assert.Throws<BussinessRuleValidationException>(() => new Categoria(nombre));
        }



        [Fact]
        public void AsignarUsuarioCreador_Should_Correct()
        {
            //Arrange or SetUp
            var nombre = "Comida";
            var usuarioDuenho = Guid.NewGuid();
            //Act
            Categoria obj = new Categoria(nombre);
            obj.AsignarUsuarioCreador(usuarioDuenho);
            //Assert or Verify
            Assert.NotNull(obj.UsuarioCreador);
            Assert.Equal(usuarioDuenho, obj.UsuarioCreador);
        }



        [Fact]
        public void AsignarUsuarioCreador_Should_Fail()
        {
            var usuarioDuenho = Guid.Empty;
            var nombre = "Comida";
            Categoria obj = new Categoria(nombre);
            Assert.Throws<BussinessRuleValidationException>(
                () => obj.AsignarUsuarioCreador(usuarioDuenho)); 
        }
 


using Domain.ValueObjects;
using Shared.Core;
using ShareKernel.ValueObjects;

namespace Domain.Test
{
    public class TestValueObjects
    {
        [Fact]
        public void Test_Invalid_GeneralName()
        {
            Assert.Throws<BussinessRuleValidationException>(() =>
            {
                NombreGeneralValue name = new NombreGeneralValue("Un nombre que sobrepase el limite de caracteres definido.");
            });

        }
        [Fact]
        public void Test_Valid_GeneralName()
        {
            //Arrange or SetUp
            var name = "Un nombre que no sobrepase el limite.";
            //Act
            NombreGeneralValue obj = new NombreGeneralValue(name);
            //Assert or Verify
            Assert.NotNull(obj.Name);
            Assert.Equal(name, obj.Name);  
        }

        [Fact]
        public void Test_Invalid_Email()
        {
            Assert.Throws<BussinessRuleValidationException>(() =>
            {
                EmailValue email = new EmailValue("accladeraom");
            });

        }
        [Fact]
        public void Test_Valid_Email()
        {
            //Arrange or SetUp
            var email = "accladera@gmail.com";
            //Act
            EmailValue obj = new EmailValue(email);
            //Assert or Verify
            Assert.NotNull(obj.Email);
            Assert.Equal(email, obj.Email);
        }
    }
}

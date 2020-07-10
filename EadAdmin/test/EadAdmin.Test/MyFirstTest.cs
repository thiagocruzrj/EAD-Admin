using Xunit;

namespace EadAdmin.Domain
{
    public class MyFirstTest
    {

        [Fact(DisplayName = "Variable 1 should equals variable 2")]
        [Trait("First Test values", "Testing values first time")]
        public void RecebeTwoVariables_IfNotEquals_ReturnTrue()
        {
            var variable1 = 1;
            var variable2 = 2;

            Assert.NotEqual(variable1, variable2);
        }
    }
}

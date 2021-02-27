using ControlSpending;
using System;
using Xunit;

namespace  ControlSpendingTests

{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            //Arrange
            var user = new User { Name = "Liza", Surname = "Andriienko" };
            var expected = "Andriienko, Liza";

            //Act
            var actual = user.FullName;

            //Assertý
            Assert.Equal(expected, actual);

        }
    }
}

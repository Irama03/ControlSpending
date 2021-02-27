using System;
using Xunit;

namespace ControlSpendingTests
{
    public class UserTest
    {

        [Fact]
        public void FullNameTestValid()
        {
            //Arrange
            var user = new User { Name = "Liza", Surname = "Andriienko" };
            var expected = "Andriienko, Liza";

            //Act
            var actual = user.FullName;

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}

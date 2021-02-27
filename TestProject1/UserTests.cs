using ControlSpending;
using System;
using Xunit;

namespace  ControlSpendingTests
{
    public class UserTests
    {
        [Fact]
        public void FullNameTest()
        {
            //Arrange
            var user = new User { Name = "Liza", Surname = "Andriienko" };
            var expected = "Andriienko, Liza";

            //Act
            var actual = user.FullName;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FullNameNoNameTest()
        {
            //Arrange
            var user = new User { Name = "Liza" };
            var expected = "Liza";

            //Act
            var actual = user.FullName;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FullNameNoSurnameTest()
        {
            //Arrange
            var user = new User { Surname = "Andriienko" };
            var expected = "Andriienko";

            //Act
            var actual = user.FullName;

            //Assert
            Assert.Equal(expected, actual);
        }

    }
}

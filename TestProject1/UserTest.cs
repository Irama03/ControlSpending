using ControlSpending;
using System;
using System.IO;
using Xunit;

namespace  ControlSpendingTests
{
    public class UserTest
    {
        [Fact]
        public void FullNameTest()
        {
            //Arrange
            var user = new User { Name = "Liza", Surname = "Andriienko" };
            var expected = "Andriienko Liza";

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

        [Fact]
        public void ValidateTest()
        {
            //Arrange
            var user = new User() { Id = 1, Name = "Liza", Surname = "Andriienko", Email = "liza123.sa@gmail.com" };

            //Act
            var actual = user.Validate();

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void ValidateNoIdTest()
        {
            //Arrange
            var user = new User() { Name = "Liza", Surname = "Andriienko", Email = "liza123.sa@gmail.com" };

            //Act
            var actual = user.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoNameTest()
        {
            //Arrange
            var user = new User() { Id = 1, Email = "liza123.sa@gmail.com" };

            //Act
            var actual = user.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoEmailTest()
        {
            //Arrange
            var user = new User() { Id = 1, Name = "Liza", Surname = "Andriienko" };

            //Act
            var actual = user.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateEmptyUserTest()
        {
            //Arrange
            var user = new User();

            //Act
            var actual = user.Validate();

            //Assert
            Assert.False(actual);
        }
    }
}

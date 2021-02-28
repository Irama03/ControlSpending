using ControlSpending;
using System;
using Xunit;

namespace ControlSpendingTests
{
    public class TransactionTest
    {
        [Fact]
        public void ValidateTest()
        {
            //Arrange
            var transaction = new Transaction()
            {
                Id = 1,
                Sum = 275.89,
                Currency = "dollar",
                Description = "new transaction",
                Date = new DateTime(2021, 7, 20),
                Files = null
            };

            //Act
            var actual = transaction.Validate();

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void ValidateNoIdTest()
        {
            //Arrange
            var transaction = new Transaction() 
            {
                Sum = 275.89,
                Currency = "dollar",
                Description = "new transaction",
                Date = new DateTime(2021, 7, 20),
                Files = null
            };

            //Act
            var actual = transaction.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoCurrencyTest()
        {
            //Arrange
            var transaction = new Transaction()
            {
                Id = 1,
                Sum = 275.89,
                Description = "new transaction",
                Date = new DateTime(2021, 7, 20),
                Files = null
            };

            //Act
            var actual = transaction.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoDescriptionTest()
        {
            //Arrange
            var transaction = new Transaction()
            {
                Id = 1,
                Sum = 275.89,
                Currency = "dollar",
                Date = new DateTime(2021, 7, 20),
                Files = null
            };

            //Act
            var actual = transaction.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoDateTest()
        {
            //Arrange
            var transaction = new Transaction()
            {
                Id = 1,
                Sum = 275.89,
                Currency = "dollar",
                Description = "new transaction",
                Files = null
            };

            //Act
            var actual = transaction.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateEmptyUserTest()
        {
            //Arrange
            var transaction = new Transaction();

            //Act
            var actual = transaction.Validate();

            //Assert
            Assert.False(actual);
        }
    }
}

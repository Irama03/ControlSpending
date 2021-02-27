using ControlSpending;
using System;
using Xunit;
using System.Collections.Generic;

namespace ControlSpendingTests
{
    public class WalletTest
    {
        [Fact]
        public void FindTransactionTest()
        {
            //Arrange
            var wallet = new Wallet()
            {
                InitialBalance = 505.3,
                Description = "new wallet",
                MainCurrency = "euro",
            };
            List<Transaction> transactions = new List<Transaction>();
            transactions.Add(
                new Transaction
                {
                    Id = 1,
                    Sum = 275.89,
                    Currency = "dollar",
                    Description = "new transaction",
                    Date = new DateTime(2021, 7, 20),
                    Files = null
                });
            transactions.Add(
               new Transaction
               {
                   Id = 2,
                   Sum = 1.11,
                   Currency = "UAH",
                   Description = "transaction in UAH",
                   Date = new DateTime(2020, 1, 15),
                   Files = null
               });
            var expected = transactions[1];

            //Act
            wallet.Transactions = transactions;
            var actual = wallet.FindTransaction(2);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidateTest()
        {
            //Arrange
            var wallet = new Wallet() 
            { 
                Name = "Wallet1", 
                InitialBalance = 505.3, 
                Description = "new wallet", 
                MainCurrency = "euro"
            };

            //Act
            var actual = wallet.Validate();

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void ValidateNoNameTest()
        {
            //Arrange
            var wallet = new Wallet()
            {
                InitialBalance = 505.3,
                Description = "new wallet",
                MainCurrency = "euro"
            };

            //Act
            var actual = wallet.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoDescriptionTest()
        {
            //Arrange
            var wallet = new Wallet()
            {
                Name = "Wallet1",
                InitialBalance = 505.3,
                MainCurrency = "euro"
            };

            //Act
            var actual = wallet.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoMainCurrencyTest()
        {
            //Arrange
            var wallet = new Wallet()
            {
                Name = "Wallet1",
                InitialBalance = 505.3,
                Description = "new wallet"
            };

            //Act
            var actual = wallet.Validate();

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

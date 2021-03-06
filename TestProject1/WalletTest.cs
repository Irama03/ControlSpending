using ControlSpending;
using System;
using Xunit;
using System.Collections.Generic;
using static ControlSpending.User;

namespace ControlSpendingTests
{
    public class WalletTest
    {
        [Fact]
        public void DeleteTransactionTest() 
        {
            //Arrange
            Wallet wallet = new Wallet()
            {
                InitialBalance = 505.3m,
                Description = "new wallet",
                MainCurrency = "euro",
            };
            List<Transaction> transactions = new List<Transaction>();
            var transaction1 = new Transaction()
            {
                Id = 1,
                Sum = 275.89m,
                Currency = "dollar",
                Description = "new transaction",
                Date = new DateTime(2021, 7, 20),
                Files = null
            };
            var transaction2 = new Transaction()
            {
                Id = 2,
                Sum = 1.11m,
                Currency = "UAH",
                Description = "transaction in UAH",
                Date = new DateTime(2020, 1, 15),
                Files = null
            };
            transactions.Add(transaction1);
            transactions.Add(transaction2);

            //Act
            wallet.Transactions = transactions;
            var actual = wallet.DeleteTransaction(1);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void ValidateTest()
        {
            //Arrange
            var wallet = new Wallet() 
            { 
                Name = "Wallet1", 
                InitialBalance = 505.3m, 
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
                InitialBalance = 505.3m,
                Description = "new wallet",
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
                InitialBalance = 505.3m,
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

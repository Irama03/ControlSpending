using ControlSpending;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace ControlSpendingTests
{
    public class WalletTest
    {
        [Fact]
        public void DeleteTransactionTest()
        {
            //Arrange
            var owner = new User()
            {
                Id = 1, 
                Name = "Ira", 
                Surname = "Matviienko", 
                Email = "ira123.sa@gmail.com"
            };

            var category = new Category()
            {
                Name = "food",
                Description = "new category food",
                Color = "red",
                Icon = new FileInfo("apple")
            };
            Wallet wallet = new Wallet(owner)
            {
                InitialBalance = 505.3m,
                Description = "new wallet",
                MainCurrency = Currencies.EUR
            };
            List<Transaction> transactions = new List<Transaction>();
            var transaction1 = new Transaction()
            {
                Id = 1,
                Sum = 275.89m,
                Currency = Currencies.USD,
                Description = "new transaction",
                Date = new DateTime(2021, 7, 20),
                Category = category,
                Files = new List<FileInfo>()
            };
            var transaction2 = new Transaction()
            {
                Id = 2,
                Sum = 1.11m,
                Currency = Currencies.UAH,
                Description = "transaction in UAH",
                Date = new DateTime(2020, 1, 15),
                Category = category,
                Files = new List<FileInfo>()
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
            var owner = new User() { Id = 1, Name = "Liza", Surname = "Andriienko", Email = "liza123.sa@gmail.com" };
            var wallet = new Wallet(owner)
            {
                Id = 1,
                Name = "Wallet1",
                InitialBalance = 505.3m,
                Description = "new wallet",
                MainCurrency = Currencies.EUR
            };

            //Act
            var actual = wallet.Validate();

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void ValidateNoIdTest()
        {
            //Arrange
            var owner = new User() { Id = 1, Name = "Liza", Surname = "Andriienko", Email = "liza123.sa@gmail.com" };
            var wallet = new Wallet(owner)
            {
                Name = "Wallet1",
                InitialBalance = 505.3m,
                Description = "new wallet",
                MainCurrency = Currencies.EUR
            };

            //Act
            var actual = wallet.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoOwnerTest()
        {
            //Arrange
            User owner = null;
            var wallet = new Wallet(owner)
            {
                Id = 1,
                Name = "Wallet1",
                InitialBalance = 505.3m,
                Description = "new wallet",
                MainCurrency = Currencies.EUR
            };

            //Act
            var actual = wallet.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoNameTest()
        {
            //Arrange
            var owner = new User() { Id = 1, Name = "Liza", Surname = "Andriienko", Email = "liza123.sa@gmail.com" };
            var wallet = new Wallet(owner)
            {
                Id = 1,
                InitialBalance = 505.3m,
                Description = "new wallet",
                MainCurrency = Currencies.EUR
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
            var owner = new User() { Id = 1, Name = "Liza", Surname = "Andriienko", Email = "liza123.sa@gmail.com" };
            var wallet = new Wallet(owner)
            {
                Id = 1,
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
        public void ValidateEmptyWalletTest()
        {
            //Arrange
            User owner = null;
            var wallet = new Wallet(owner);

            //Act
            var actual = wallet.Validate();

            //Assert
            Assert.False(actual);
        }
    }
}
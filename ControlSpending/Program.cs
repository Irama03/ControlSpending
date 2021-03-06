using System;
using System.Collections.Generic;
using System.IO;
using static ControlSpending.User;

namespace ControlSpending
{
    class Program
    {
        static void Main(string[] args)
        {
            var owner1 = new User() { Name = "Liza", Surname = "Andriienko", Email = "liza123.sa@gmail.com" };
            var owner2 = new User() { Name = "Ira", Surname = "Matviienko", Email = "ira123.sa@gmail.com" };
            List<Category> categories = new List<Category>();
            var category = new Category()
            {
                Name = "food",
                Description = "new category food",
                Color = "red",
                Icon = new FileInfo("apple")
            };
            categories.Add(category);
            owner1.Categories = categories;

            var wallet = new Wallet()
            {
                Owner = owner1,
                Name = "Wallet1",
                InitialBalance = 505.3m,
                Description = "new wallet",
                MainCurrency = "euro"
            };

            List<Transaction> transactions = new List<Transaction>();
            var transaction1 = new Transaction()
            {
                Id = 1,
                Sum = 275.89m,
                Currency = "dollar",
                Date = new DateTime(2021, 7, 20),
                Category = category
            };
            var transaction2 = new Transaction()
            {
                Id = 2,
                Sum = 1.11m,
                Currency = "UAH",
                Description = "transaction in UAH",
                Date = new DateTime(2020, 1, 15),
                Category = category
            };
            transactions.Add(transaction1);
            transactions.Add(transaction2);

            wallet.Transactions = transactions;
            wallet.ShowTransactions();

            var wallet2 = new Wallet()
            {
                Owner = owner2,
                Name = "Wallet1",
                InitialBalance = 505.3m,
                Description = "new wallet",
                MainCurrency = "euro"
            };

            List<Transaction> transactions2 = new List<Transaction>();
            var transaction21 = new Transaction()
            {
                Id = 6,
                Sum = 275.89m,
                Currency = "dollar",
                Date = new DateTime(2021, 7, 20),
                Category = category
            };
            var transaction22 = new Transaction()
            {
                Id = 7,
                Sum = 1.11m,
                Currency = "UAH",
                Description = "transaction in UAH",
                Date = new DateTime(2020, 1, 15),
                Category = category
            };
            transactions.Add(transaction21);
            transactions.Add(transaction22);
            wallet2.Transactions = transactions2;

            Console.WriteLine();

             owner2.Wallets.

            //var transaction3 = new Transaction()
            //{
            //    Id = 3,
            //    Sum = 27m,
            //    Currency = "euro",
            //    Description = "new transaction",
            //    Date = new DateTime(2021, 6, 3),
            //    Category = category
            //};
            //wallet.AddTransaction(transaction3);
            //wallet.ShowTransactions();
        }
    }
}

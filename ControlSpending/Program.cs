using System;
using System.Collections.Generic;
using System.IO;

namespace ControlSpending
{
    class Program
    {
        static void Main(string[] args)
        {
            Guid id1 = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();
            Guid id3 = Guid.NewGuid();
            var owner1 = new User(id1, "Liza", "Andriienko", "liza123.sa@gmail.com");
            var owner2 = new User(id2, "Ira", "Matviienko", "ira123.sa@gmail.com");
            var owner3 = new User(id3, "Vova", "Apple", "vova123.sa@gmail.com");

            List<Category> categories = new List<Category>();
            var category = new Category("food", "red", "coins.txt");
            categories.Add(category);
            owner1.Categories = categories;

            Guid id4 = Guid.NewGuid();
            var wallet = new Wallet(owner1, id4, "Wallet1", 505.3m, Currencies.EUR);

            List<Transaction> transactions = new List<Transaction>();
            Guid id5 = Guid.NewGuid();
            Guid id6 = Guid.NewGuid();
            var transaction1 = new Transaction(id5, 275.89m, Currencies.USD, new DateTimeOffset(2021, 7, 20, 14, 10, 5, new TimeSpan(2, 0, 0)), category);
            var transaction2 = new Transaction(id6, 1.11m, Currencies.UAH, new DateTimeOffset(2021, 7, 20, 14, 10, 5, new TimeSpan(2, 0, 0)), category);
            transactions.Add(transaction1);
            transactions.Add(transaction2);

            wallet.Transactions = transactions;
            wallet.ShowTransactions();
            Console.WriteLine();
            wallet.ShowAvailableCategories();



            //var wallet2 = new Wallet(owner2, 2, "Wallet2", 202.4m, Currencies.USD);

            //List<Transaction> transactions2 = new List<Transaction>();
            //var transaction21 = new Transaction(6, 275.89m, Currencies.USD, new DateTime(2021, 7, 20), category);
            //var transaction22 = new Transaction(7, 1.11m, Currencies.UAH, new DateTime(2020, 1, 15), category);
            //transactions2.Add(transaction21);
            //transactions2.Add(transaction22);
            //wallet2.Transactions = transactions2;


            Guid id7 = Guid.NewGuid();
            var transaction3 = new Transaction(id7, 1.112292929m, Currencies.UAH, new DateTimeOffset(2011, 4, 2, 14, 10, 5, new TimeSpan(2, 0, 0)), category);
           

            Console.WriteLine();
            //owner1.ShowMyWallets();

            owner1.shareWallet(owner2, wallet);
            owner1.MyWallets[0].AddTransaction(transaction3, id2);
            

           // wallet.AddTransaction(3, transaction3);

            Console.WriteLine();
            wallet.ShowTransactions();
        }
    }
}

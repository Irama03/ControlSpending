using System;
using System.Collections.Generic;
using System.IO;

namespace ControlSpending
{
    class Program
    {
        static void Main(string[] args)
        {
            var owner1 = new User(1, "Liza", "Andriienko", "liza123.sa@gmail.com");
            var owner2 = new User(2, "Ira", "Matviienko", "ira123.sa@gmail.com");
            var owner3 = new User(3, "Vova", "Apple", "vova123.sa@gmail.com");

            List<Category> categories = new List<Category>();
            var category = new Category("food", "red", "coins.txt");
            categories.Add(category);
            owner1.Categories = categories;

            var wallet = new Wallet(owner1, 1,"Wallet1", 505.3m, Currencies.EUR);

            List<Transaction> transactions = new List<Transaction>();
            var transaction1 = new Transaction(1, 275.89m, Currencies.USD, new DateTime(2021, 7, 20), category);
            var transaction2 = new Transaction(2, 1.11m, Currencies.UAH, new DateTime(2020, 1, 15), category);
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



            var transaction3 = new Transaction(3, 1.112292929m, Currencies.UAH, new DateTime(1910, 10, 5), category);
           

            Console.WriteLine();
            owner1.ShowMyWallets();

            owner1.shareWallet(owner2, wallet);
            wallet.AddTransaction(2, transaction3);
           // wallet.AddTransaction(3, transaction3);

            Console.WriteLine();
            wallet.ShowTransactions();
        }
    }
}

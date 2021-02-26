using System;
using System.Collections.Generic;

namespace ControlSpending
{
    //Гаманець. Повинен зберігати назву, початковий баланс гаманця, опис та
    //основну валюту. До нього додаються транзакції. Для кожного гаманця можна
    //вказати список категорій, який доступний в ньому для транзакцій.
    public class Wallet
    {
        private string _name;
        private double _initialBalance = 0;
        private string _description;
        private string _mainCurrency;
        private List<Transaction> _transactions;
        private List<Category> _categories;
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public double InitialBalance
        {
            get { return _initialBalance; }
            set { _initialBalance = value; }
        }
        
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        
        public string MainCurrency
        {
            get { return _mainCurrency; }
            set { _mainCurrency = value; }
        }
        
        public List<Transaction> Transactions
        {
            get
            {
                return _transactions;
            }
        }
        
        public List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }
        
        public Wallet()
        {
            _transactions = new List<Transaction>();
            _categories = new List<Category>();
        }

        public Wallet(string name, double initialBalance, string description, 
            string mainCurrency, List<Category> categories)
        {
            _name = name;
            _initialBalance = initialBalance;
            _description = description;
            _mainCurrency = mainCurrency;
            _transactions = new List<Transaction>();
            _categories = categories;
        }

        public void addTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public Transaction getTransaction(string transactionName)
        {
            foreach (var transaction in Transactions)
            {
                if (transaction.Name.Equals(transactionName))
                {
                    return transaction;
                }
            }
            Console.WriteLine("The transaction is not found");
            return null;
        }
        
        /*public void deleteTransaction(Transaction transaction)
        {
            bool response = _transactions.Remove(transaction);
            if (!response)
            {
                Console.WriteLine("The transaction is not found");
            }
            else
            {
                Console.WriteLine("The transaction was deleted successfully");
            }
        }*/
        
        public void deleteTransaction(string transactionName)
        {
            var response = false;
            foreach (var transaction in Transactions)
            {
                if (transaction.Name.Equals(transactionName))
                {
                    _transactions.Remove(transaction);
                    response = true;
                    break;
                }
            }
            if (!response)
            {
                Console.WriteLine("The transaction is not found");
            }
            else
            {
                Console.WriteLine("The transaction was deleted successfully");
            }
        }
        
        public override string ToString()
        {
            return $"{Name}, {InitialBalance}, {Description}, {MainCurrency}";
        }
    }
}
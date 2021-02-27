using System;
using System.Collections.Generic;

namespace ControlSpending
{
    // Class Wallet keeps the name, initial wallet balance, description and base currency. 
    // Transactions are added to it. For each wallet, you can specify a list of categories that are available in it for transactions.
    public class Wallet : Entity
    {
        private string _name;
        private double _initialBalance = 0;
        private double _currentBalance;
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
        
        public double CurrentBalance
        {
            get { return _currentBalance; }
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
            get { return _transactions; }
            set { _transactions = value; }
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
            _currentBalance = _initialBalance;
            _transactions = new List<Transaction>();
            _categories = new List<Category>();
        }

        public Wallet(string name, double initialBalance, string description, 
            string mainCurrency, List<Category> categories)
        {
            _name = name;
            _initialBalance = initialBalance;
            _currentBalance = _initialBalance;
            _description = description;
            _mainCurrency = mainCurrency;
            _transactions = new List<Transaction>();
            _categories = categories;
        }

        public Transaction FindTransaction(int transactionId)
        {
            foreach (var transaction in Transactions)
            {
                if (transaction.Id.CompareTo(transactionId) == 0)
                {
                    Console.WriteLine("+");
                    return transaction;
                }
            }
            Console.WriteLine("The transaction is not found");
            return null;
        }

        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
            //_currentBalance += transaction.Sum;
        }

        /*public Transaction getTransaction(string transactionName)
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
        }*/
        
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
        
        //TODO: Write other edit-methods of transactions

        public void EditSumOfTransaction(int transactionId, double newSum)
        {
            Transaction transaction = FindTransaction(transactionId);
            if (transaction != null)
            {
                //transaction.Sum = newSum;
                //_currentBalance += transaction.Sum;
                Console.WriteLine("Sum of the transaction was edited successfully");
            }
        }
        
        public void DeleteTransaction(int transactionId)
        {
            Transaction transaction = FindTransaction(transactionId);
            if (transaction != null)
            {
                _transactions.Remove(transaction);
                //_currentBalance -= transaction.Sum;
                Console.WriteLine("The transaction was deleted successfully");
            }
        }
        
        public void AddCategory(Category category)
        {
            _categories.Add(category);
        }
        
        public void DeleteCategory(string categoryName)
        {
            var response = false;
            foreach (var category in Categories)
            {
                if (category.Name.Equals(categoryName))
                {
                    _categories.Remove(category);
                    response = true;
                    break;
                }
            }
            if (!response)
            {
                Console.WriteLine("The category is not found");
            }
            else
            {
                Console.WriteLine("The category was deleted successfully");
            }
        }

        public override bool Validate()
        {
            var result = true;

            if (String.IsNullOrWhiteSpace(Name))
                result = false;
            if (String.IsNullOrWhiteSpace(Description))
                result = false;
            if (String.IsNullOrWhiteSpace(MainCurrency))
                result = false;

            return result;
        }

        public override string ToString()
        {
            return $"{Name}, {InitialBalance}, {Description}, {MainCurrency}";
        }
    }
}
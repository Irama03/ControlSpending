using System;
using System.Collections.Generic;
using System.IO;

namespace ControlSpending
{
    // Class User keeps name, surname, email address. It can have an unlimited number of wallets and categories.
    public class User : Entity
    {
        private string _name;
        private string _surname;
        private string _email;
        private List<Wallet> _wallets;
        private List<Category> _categories;

        public User()
        {
            _wallets = new List<Wallet>();
            _categories = new List<Category>();
        }

        public User(string name, string surname, string email, List<Wallet> wallets, List<Category> categories)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _wallets = wallets;
            _categories = categories;
        }

        public string Name 
        { 
            get { return _name; } 
            set { _name = value; } 
        }

        public string Surname 
        { 
            get { return _surname; } 
            set { _surname = value; } 
        }

        public string Email 
        { 
            get { return _email; } 
            set { _email = value; } 
        }

        public List<Wallet> Wallets
        {
            get
            {
                return _wallets;
            }
        }

        public List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }

        public string FullName 
        {
            get
            {
                var result = Surname;
                if (!String.IsNullOrWhiteSpace(Name))
                {
                    if (!String.IsNullOrWhiteSpace(Surname))
                    {
                        result += ", ";
                    }
                    result += Name;
                }
                return result;
            }
        }

        public override bool Validate()
        {
            var result = true;

            if (String.IsNullOrWhiteSpace(Name))
                result = false;
            if (String.IsNullOrWhiteSpace(Surname))
                result = false;
            if (String.IsNullOrWhiteSpace(Email))
                result = false;

            return result;
        }

        public override string ToString()
        {
            return FullName;
        }
        
        // Class Wallet keeps the name, initial wallet balance, description and base currency. 
        // Transactions are added to it. For each wallet, you can specify a list of categories that are available in it for transactions.
        public class Wallet : Entity
        {
            private User _owner;
            private string _name;
            private double _initialBalance;
            private double _currentBalance;
            private string _description;
            private string _mainCurrency;
            private List<Transaction> _transactions;
            //private List<Category> _categories;
            private List<bool> _availabilityOfCategories;
        
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            
            public double InitialBalance
            {
                get { return _initialBalance; }
                set
                {
                    _currentBalance -= _initialBalance;
                    _initialBalance = value;
                    _currentBalance += _initialBalance;
                }
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
            
            /*public List<Category> Categories
            {
                get
                {
                    return _categories;
                }
            }*/
            
            public Wallet(User user)
            {
                _owner = user;
                //_currentBalance = _initialBalance = 0;
                _transactions = new List<Transaction>();
                //_categories = new List<Category>();
                _availabilityOfCategories = new List<bool>();
                for(int i = 0; i < _owner._categories.Count; i++)
                {
                    _availabilityOfCategories.Add(true);
                }
            }

            public Wallet(User user, string name, double initialBalance, string description, 
                string mainCurrency)//, List<Category> categories)
            {
                _name = name;
                _initialBalance = initialBalance;
                _currentBalance = _initialBalance;
                _description = description;
                _mainCurrency = mainCurrency;
                _transactions = new List<Transaction>();
                //_categories = categories;
                _availabilityOfCategories = new List<bool>();
                for(int i = 0; i < Transactions.Count; i++)
                {
                    _availabilityOfCategories.Add(true);
                }
            }

            private Transaction FindTransaction(int transactionId)
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
                _currentBalance += transaction.Sum;
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

            public void EditIdOfTransaction(int transactionId, int newId)
            {
                var transaction = FindTransaction(transactionId);
                if (transaction != null)
                {
                    transaction.Id = newId;
                    Console.WriteLine("Id of the transaction was edited successfully");
                }
            }

            public void EditSumOfTransaction(int transactionId, double newSum)
            {
                var transaction = FindTransaction(transactionId);
                if (transaction != null)
                {
                    transaction.Sum = newSum;
                    _currentBalance += transaction.Sum;
                    Console.WriteLine("Sum of the transaction was edited successfully");
                }
            }
            
            public void EditCurrencyOfTransaction(int transactionId, string newCurrency)
            {
                var transaction = FindTransaction(transactionId);
                if (transaction != null)
                {
                    transaction.Currency = newCurrency;
                    Console.WriteLine("Currency of the transaction was edited successfully");
                }
            }
            
            public void EditDescriptionOfTransaction(int transactionId, string newDescription)
            {
                var transaction = FindTransaction(transactionId);
                if (transaction != null)
                {
                    transaction.Description = newDescription;
                    Console.WriteLine("Description of the transaction was edited successfully");
                }
            }
            
            public void EditDateOfTransaction(int transactionId, DateTime newDate)
            {
                var transaction = FindTransaction(transactionId);
                if (transaction != null)
                {
                    transaction.Date = newDate;
                    Console.WriteLine("Date of the transaction was edited successfully");
                }
            }
            
            public void EditFilesOfTransaction(int transactionId, List<FileInfo> newFiles)
            {
                var transaction = FindTransaction(transactionId);
                if (transaction != null)
                {
                    transaction.Files = newFiles;
                    Console.WriteLine("Files of the transaction were edited successfully");
                }
            }
            
            //Should AddFile() in Transaction be private?
            
            /*public void AddFileToTransaction(int transactionId, FileInfo newFile)
            {
                var transaction = FindTransaction(transactionId);
                if (transaction != null)
                {
                    transaction.AddFile(newFile);
                    Console.WriteLine("New file was added to the transaction successfully");
                }
            }*/
            
            public bool DeleteTransaction(int transactionId)
            {
                var transaction = FindTransaction(transactionId);
                if (transaction != null)
                {
                    _transactions.Remove(transaction);
                    _currentBalance -= transaction.Sum;
                    Console.WriteLine("The transaction was deleted successfully");
                    return true;
                }
                return false;
            }
            
            /*public void AddCategory(Category category)
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
            }*/

            double generalSumOfIncomeForMonth()
            {
                double result = 0;
                int currMonth = DateTime.Now.Month;
                foreach (var transaction in Transactions)
                {
                    if (transaction.Date != null && transaction.Date.Value.Month == currMonth)
                    {
                        if (transaction.Sum > 0)
                        {
                            result += transaction.Sum;
                        }
                    }
                }
                return result;
            }
            
            double generalSumOfSpendingsForMonth()
            {
                double result = 0;
                int currMonth = DateTime.Now.Month;
                foreach (var transaction in Transactions)
                {
                    if (transaction.Date != null && transaction.Date.Value.Month == currMonth)
                    {
                        if (transaction.Sum < 0)
                        {
                            result += transaction.Sum;
                        }
                    }
                }
                return Math.Abs(result);
            }

            public void showTransactions(int start = 0, int finish = 9)
            {
                int lastIndexOfTrans = Transactions.Count - 1;
                if (start < 0 || finish < 0 || finish < start || start > lastIndexOfTrans)
                {
                    Console.WriteLine("Invalid index!");
                }
                else
                {
                    if (finish > lastIndexOfTrans)
                    {
                        finish = lastIndexOfTrans;
                    }
                    var i = 0;
                    foreach (var transaction in Transactions)
                    {
                        if (i >= start && i <= finish)
                        {
                            Console.WriteLine(i + ") " + transaction);
                        }
                        i++;
                        if (i > finish)
                        {
                            break;
                        }
                    }
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
}
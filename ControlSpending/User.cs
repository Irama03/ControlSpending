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

        public User(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _wallets = new List<Wallet>();
            _categories = new List<Category>();
            if (!Validate())
            {
                throw new ArgumentException("Invalid argument in constructor of User!");
            }
        }

        public string Name 
        { 
            get { return _name; } 
            set 
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
                else
                {
                    Console.WriteLine("Invalid value of Name!");
                }
            } 
        }

        public string Surname 
        { 
            get { return _surname; } 
            set 
            { 
                if (!String.IsNullOrWhiteSpace(value))
                {
                    _surname = value;
                }
                else
                {
                    Console.WriteLine("Invalid value of Surname!");
                }
            } 
        }

        public string Email 
        { 
            get { return _email; } 
            set 
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    _email = value;
                }
                else
                {
                    Console.WriteLine("Invalid value of Email!");
                }
            } 
        }

        public List<Wallet> Wallets
        {
            get { return _wallets; }
        }

        public List<Category> Categories
        {
            get { return _categories; }
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
                        result += ' ';
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
                set
                {
                    if (!String.IsNullOrWhiteSpace(value))
                    {
                        _name = value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid value of Name!");
                    }
                }
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
                set
                {
                    if (!String.IsNullOrWhiteSpace(value))
                    {
                        _description = value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid value of Description!");
                    }
                }
            }
            
            public string MainCurrency
            {
                get { return _mainCurrency; }
                set
                {
                    if (!String.IsNullOrWhiteSpace(value))
                    {
                        _mainCurrency = value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid value of MainCurrency!");
                    }
                }
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
                if (_owner.Categories != null)
                {
                    for(int i = 0; i < _owner._categories.Count; i++)
                    {
                        _availabilityOfCategories.Add(true);
                    }
                }
            }

            public Wallet(User user, string name, double initialBalance, string description, 
                string mainCurrency)//, List<Category> categories)
            {
                _owner = user;
                _name = name;
                _initialBalance = initialBalance;
                _currentBalance = _initialBalance;
                _description = description;
                _mainCurrency = mainCurrency;
                _transactions = new List<Transaction>();
                //_categories = categories;
                _availabilityOfCategories = new List<bool>();
                if (_owner.Categories != null)
                {
                    for(int i = 0; i < _owner._categories.Count; i++)
                    {
                        _availabilityOfCategories.Add(true);
                    }
                }
                if (!Validate())
                {
                    throw new ArgumentException("Invalid argument in constructor of Wallet!");
                }
            }

            public Wallet() {}

            private bool IsAvailable(Category category)
            {
                return (_availabilityOfCategories[_owner.Categories.IndexOf(category)]);
            }

            private bool TransactionIdIsValid(int transactionId)
            {
                bool result = transactionId >= 0;
                if (!result)
                {
                    Console.WriteLine("Invalid transactionId!");
                }
                return result;
            }

            private Transaction FindTransaction(int transactionId)
            {
                if (TransactionIdIsValid(transactionId))
                {
                    foreach (var transaction in Transactions)
                    {
                        if (transaction.Id == transactionId)
                        {
                            Console.WriteLine("+");
                            return transaction;
                        }
                    }
                    Console.WriteLine("The transaction is not found");
                }
                return null;
            }

            public void AddTransaction(Transaction transaction)
            {
                foreach (var t in Transactions)
                {
                    if (t.Id == transaction.Id)
                    {
                        Console.WriteLine("Transaction with this id already exists!");
                        return;
                    }
                }
                if (!(_owner.Categories.Contains(transaction.Category)))
                {
                    Console.WriteLine("Transaction with unknown Category can't be added!");
                    return;
                }
                if (!IsAvailable(transaction.Category))
                {
                    Console.WriteLine("Category of the transaction is unavailable. " 
                                      + "Transaction can't be added!");
                    return;
                }
                _transactions.Add(transaction);
                _currentBalance += transaction.Sum;
                Console.WriteLine("The transaction was added successfully");
            }

            public void EditIdOfTransaction(int transactionId, int newId)
            {
                if (TransactionIdIsValid(transactionId) && TransactionIdIsValid(newId))
                {
                    var transaction = FindTransaction(transactionId);
                    if (transaction != null)
                    {
                        transaction.Id = newId;
                        Console.WriteLine("Id of the transaction was edited successfully");
                    }
                }
            }

            public void EditSumOfTransaction(int transactionId, double newSum)
            {
                if (TransactionIdIsValid(transactionId))
                {
                    var transaction = FindTransaction(transactionId);
                    if (transaction != null)
                    {
                        _currentBalance -= transaction.Sum;
                        transaction.Sum = newSum;
                        _currentBalance += transaction.Sum;
                        Console.WriteLine("Sum of the transaction was edited successfully");
                    }
                }
            }
            
            public void EditCurrencyOfTransaction(int transactionId, string newCurrency)
            {
                if (TransactionIdIsValid(transactionId))
                {
                    if (!String.IsNullOrWhiteSpace(newCurrency))
                    {
                        var transaction = FindTransaction(transactionId);
                        if (transaction != null)
                        {
                            transaction.Currency = newCurrency;
                            Console.WriteLine("Currency of the transaction was edited successfully");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid value of newCurrency!");
                    }
                }
            }
            
            public void EditDescriptionOfTransaction(int transactionId, string newDescription)
            {
                if (TransactionIdIsValid(transactionId))
                {
                    if (!String.IsNullOrWhiteSpace(newDescription))
                    {
                        var transaction = FindTransaction(transactionId);
                        if (transaction != null)
                        {
                            transaction.Description = newDescription;
                            Console.WriteLine("Description of the transaction was edited successfully");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid value of newDescription!");
                    }
                }
            }
            
            public void EditDateOfTransaction(int transactionId, DateTime newDate)
            {
                if (TransactionIdIsValid(transactionId))
                {
                    var transaction = FindTransaction(transactionId);
                    if (transaction != null)
                    {
                        transaction.Date = newDate;
                        Console.WriteLine("Date of the transaction was edited successfully");
                    }
                }
            }
            
            public void EditCategoryOfTransaction(int transactionId, Category newCategory)
            {
                if (TransactionIdIsValid(transactionId))
                {
                    if (!(_owner.Categories.Contains(newCategory)))
                    {
                        Console.WriteLine("Category of the Transaction can't be changed to unknown Category!");
                        return;
                    }
                    if (!IsAvailable(newCategory))
                    {
                        Console.WriteLine("New category of the transaction is unavailable. " 
                                          + "Category of the Transaction can't be changed!");
                        return;
                    }
                    var transaction = FindTransaction(transactionId);
                    if (transaction != null)
                    {
                        transaction.Category = newCategory;
                        Console.WriteLine("Category of the transaction was edited successfully");
                    }
                }
            }

            public void EditFilesOfTransaction(int transactionId, List<FileInfo> newFiles)
            {
                if (TransactionIdIsValid(transactionId))
                {
                    var transaction = FindTransaction(transactionId);
                    if (transaction != null)
                    {
                        transaction.Files = newFiles;
                        Console.WriteLine("Files of the transaction were edited successfully");
                    }
                }
            }
            
            //Should AddFile() in Transaction be private?
            
            /*public void AddFileToTransaction(int transactionId, FileInfo newFile)
            {
            if (transactionIdIsValid(transactionId))
                {
                    var transaction = FindTransaction(transactionId);
                    if (transaction != null)
                    {
                        transaction.AddFile(newFile);
                        Console.WriteLine("New file was added to the transaction successfully");
                    }
                }
            }*/
            
            public bool DeleteTransaction(int transactionId)
            {
                if (TransactionIdIsValid(transactionId))
                {
                    var transaction = FindTransaction(transactionId);
                    if (transaction != null)
                    {
                        _transactions.Remove(transaction);
                        _currentBalance -= transaction.Sum;
                        Console.WriteLine("The transaction was deleted successfully");
                        return true;
                    }
                }
                return false;
            }
            
            public void ChangeAvailabilityOfCategory(string categoryName, bool availability)
            {
                int index = 0;
                foreach (var category in _owner.Categories)
                {
                    if (category.Name.Equals(categoryName))
                    {
                        _availabilityOfCategories[index] = availability;
                        Console.WriteLine("Availability of the category was changed successfully");
                        return;
                    }
                    index++;
                }
                Console.WriteLine("The category is not found");
            }

            public double GeneralSumOfIncomeForMonth()
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
            
            public double GeneralSumOfSpendingsForMonth()
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

            public void ShowTransactions(int start = 0, int finish = 9)
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

            public void ShowAvailableCategories()
            {
                foreach (var category in _owner.Categories)
                {
                    if (IsAvailable(category))
                    {
                        Console.WriteLine(category);
                        return;
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
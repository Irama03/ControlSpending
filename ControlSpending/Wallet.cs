using System;
using System.IO;
using System.Collections.Generic;

namespace ControlSpending
{
    // Class Wallet keeps the name, initial wallet balance, description and base currency. 
    // Transactions are added to it. For each wallet, you can specify a list of categories that are available in it for transactions.
    public class Wallet : Entity
    {
        private User _owner;
        private int _id;
        private string _name;
        private decimal _initialBalance;
        private decimal _currentBalance;
        private string _description;
        private Currencies? _mainCurrency;
        private List<Transaction> _transactions;
        private List<bool> _availabilityOfCategories;
        private List<int> _usersId;

        public User Owner
        {
            get { return _owner; }
        }
        
        public int Id
        {
            get { return _id; }
            set
            {
                if (value >= 0)
                {
                    _id = value;
                }
                else
                {
                    Console.WriteLine("Invalid value of Id!");
                }
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

        public decimal InitialBalance
        {
            get { return _initialBalance; }
            set
            {
                _currentBalance -= _initialBalance;
                _initialBalance = value;
                _currentBalance += _initialBalance;
            }
        }

        public decimal CurrentBalance
        {
            get { return _currentBalance; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Currencies? MainCurrency
        {
            get { return _mainCurrency; }
            set { _mainCurrency = value; }
        }

        public List<Transaction> Transactions
        {
            set { _transactions = value; }
        }

        public List<int> UsersId
        {
            get { return _usersId; }
            set { _usersId = value; }
        }

        public Wallet(User user)
        {
            _owner = user;
            _transactions = new List<Transaction>();
            _availabilityOfCategories = new List<bool>();
            _usersId = new List<int>();
            _usersId.Add(_owner.Id);
            if (_owner.Categories != null)
            {
                for (int i = 0; i < _owner.CategoriesAmount(); i++)
                {
                    _availabilityOfCategories.Add(true);
                }
            }
        }

        public Wallet(User user, int id, string name, decimal initialBalance, Currencies? mainCurrency)
        {
            _owner = user;
            _id = id;
            _name = name;
            _initialBalance = initialBalance;
            _currentBalance = _initialBalance;
            _mainCurrency = mainCurrency;
            _transactions = new List<Transaction>();
            _availabilityOfCategories = new List<bool>();
            _usersId = new List<int>();
            _usersId.Add(_owner.Id);
            if (_owner.Categories != null)
            {
                for (int i = 0; i < _owner.CategoriesAmount(); i++)
                {
                    _availabilityOfCategories.Add(true);
                }
            }
            if (!Validate())
            {
                throw new ArgumentException("Invalid argument in constructor of Wallet!");
            }
            user.MyWallets.Add(this);
        }

        public bool IsAvailable(Category category)
        {
            return (_availabilityOfCategories[Owner.Categories.IndexOf(category)]);
        }

        private bool userIsOwner(int userId)
        {
            bool result = (userId == Owner.Id);
            if (!result)
            {
                Console.WriteLine("User can't perform the action because he/she isn't an owner!");
            }
            return result;
        }

        private Transaction FindTransaction(int transactionId)
        {
            if (IsValidId(transactionId))
            {
                foreach (var transaction in _transactions)
                {
                    if (transaction.Id == transactionId)
                    {
                        return transaction;
                    }
                }
                Console.WriteLine("The transaction is not found");
            }
            return null;
        }
        
        public void AddTransaction(Transaction transaction, int userId)
        {
            foreach (var u in _usersId)
            {
                if (u != userId)
                {
                    Console.WriteLine("User with this id can't add transaction to this wallet!");
                    return;
                }
            }
            foreach (var t in _transactions)
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
            _currentBalance += TransformCurrency(transaction.Currency, MainCurrency, transaction.Sum);
            Console.WriteLine("The transaction was added successfully");
        }

        public void EditIdOfTransaction(int transactionId, int newId, int userId)
        {
            if (userIsOwner(userId))
            {
                if (IsValidId(transactionId) && IsValidId(newId))
                {
                    var transaction = FindTransaction(transactionId);
                    if (transaction != null)
                    {
                        transaction.Id = newId;
                        Console.WriteLine("Id of the transaction was edited successfully");
                    }
                }
            }
        }

        public void EditSumOfTransaction(int transactionId, decimal newSum, int userId)
        {
            if (userIsOwner(userId))
            {
                if (IsValidId(transactionId))
                {
                    var transaction = FindTransaction(transactionId);
                    if (transaction != null)
                    {
                        _currentBalance -= transaction.Sum;
                        transaction.Sum = newSum;
                        _currentBalance += TransformCurrency(transaction.Currency, MainCurrency, transaction.Sum);
                        Console.WriteLine("Sum of the transaction was edited successfully");
                    }
                }
            }
        }

        public void EditCurrencyOfTransaction(int transactionId, Currencies newCurrency, int userId)
        {
            if (userIsOwner(userId))
            {
                if (IsValidId(transactionId))
                {
                    var transaction = FindTransaction(transactionId);
                    if (transaction != null)
                    {
                        transaction.Currency = newCurrency;
                        Console.WriteLine("Currency of the transaction was edited successfully");
                    }
                }
            }
        }

        public void EditDescriptionOfTransaction(int transactionId, string newDescription, int userId)
        {
            if (userIsOwner(userId))
            {
                if (IsValidId(transactionId))
                {
                    var transaction = FindTransaction(transactionId);
                    if (transaction != null)
                    {
                        transaction.Description = newDescription;
                        Console.WriteLine("Description of the transaction was edited successfully");
                    }
                }
            }
        }

        public void EditDateOfTransaction(int transactionId, DateTime newDate, int userId)
        {
            if (userIsOwner(userId))
            {
                if (IsValidId(transactionId))
                {
                    var transaction = FindTransaction(transactionId);
                    if (transaction != null)
                    {
                        transaction.Date = newDate;
                        Console.WriteLine("Date of the transaction was edited successfully");
                    }
                }
            }
        }

        public void EditCategoryOfTransaction(int transactionId, Category newCategory, int userId)
        {
            if (userIsOwner(userId))
            {
                if (IsValidId(transactionId))
                {
                    if (!(Owner.Categories.Contains(newCategory)))
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
        }

        public void EditFilesOfTransaction(int transactionId, List<FileInfo> newFiles, int userId)
        {
            if (userIsOwner(userId))
            {
                if (IsValidId(transactionId))
                {
                    var transaction = FindTransaction(transactionId);
                    if (transaction != null)
                    {
                        transaction.Files = newFiles;
                        Console.WriteLine("Files of the transaction were edited successfully");
                    }
                }
            }
        }

        public void AddFileToTransaction(int transactionId, string pathToNewFile, int userId)
        {
            if (userIsOwner(userId))
            {
                if (IsValidId(transactionId))
                {
                    var transaction = FindTransaction(transactionId);
                    if (transaction != null)
                    {
                        transaction.AddFile(pathToNewFile);
                        Console.WriteLine("New file was added to the transaction successfully");
                    }
                }
            }
        }

        public bool DeleteTransaction(int transactionId, int userId)
        {
            if (userIsOwner(userId))
            {
                if (IsValidId(transactionId))
                {
                    var transaction = FindTransaction(transactionId);
                    if (transaction != null)
                    {
                        _transactions.Remove(transaction);
                        _currentBalance -= TransformCurrency(transaction.Currency, MainCurrency, transaction.Sum);
                        Console.WriteLine("The transaction was deleted successfully");
                        return true;
                    }
                }
            }
            return false;
        }

        public void ChangeAvailabilityOfCategory(string categoryName, bool availability, int userId)
        {
            if (userIsOwner(userId))
            {
                int index = 0;
                foreach (var category in Owner.Categories)
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
        }

        public decimal GeneralSumOfIncomeForMonth()
        {
            decimal result = 0;
            int currMonth = DateTime.Now.Month;
            foreach (var transaction in _transactions)
            {
                if (transaction.Date != null && transaction.Date.Value.Month == currMonth)
                {
                    if (transaction.Sum > 0)
                    {
                        result += TransformCurrency(transaction.Currency, MainCurrency, transaction.Sum);
                    }
                }
            }
            return result;
        }

        public decimal GeneralSumOfSpendingsForMonth()
        {
            decimal result = 0;
            int currMonth = DateTime.Now.Month;
            foreach (var transaction in _transactions)
            {
                if (transaction.Date != null && transaction.Date.Value.Month == currMonth)
                {
                    if (transaction.Sum < 0)
                    {
                        result += TransformCurrency(transaction.Currency, MainCurrency, transaction.Sum);
                    }
                }
            }
            return Math.Abs(result);
        }

        public void ShowTransactions(int start = 0, int finish = 9)
        {
            int lastIndexOfTrans = _transactions.Count - 1;
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
                foreach (var transaction in _transactions)
                {
                    if (i >= start && i <= finish)
                    {
                        Console.WriteLine(i + 1 + ") " + transaction);
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
            foreach (var category in Owner.Categories)
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

            if (Id <= 0)
                result = false;
            if (Owner == null)
                result = false;
            if (String.IsNullOrWhiteSpace(Name))
                result = false;
            if (MainCurrency == null)
                result = false;
            return result;
        }

        public override string ToString()
        {
            if (Description != null)
            {
                return $"{Name}, {InitialBalance}, {Description}, {MainCurrency}";
            }
            else
            {
                return $"{Name}, {InitialBalance}, {MainCurrency}";
            }
        }
    }
}

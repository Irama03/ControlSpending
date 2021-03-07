using System;
using System.Collections.Generic;
using System.IO;

namespace ControlSpending
{
    // Class User keeps name, surname, email address. It can have an unlimited number of wallets and categories.
    public class User : Entity
    {
        private int _id;
        private string _name;
        private string _surname;
        private string _email;
        private List<Wallet> _myWallets;
        private List<Wallet> _otherWallets;
        private List<Category> _categories;
        private List<User> _friends;

        public User()
        {
            _myWallets = new List<Wallet>();
            _otherWallets = new List<Wallet>();
            _categories = new List<Category>();
            _friends = new List<User>();
        }

        public User(int id, string name, string surname, string email)
        {
            _id = id;
            _name = name;
            _surname = surname;
            _email = email;
            _myWallets = new List<Wallet>();
            _otherWallets = new List<Wallet>();
            _categories = new List<Category>();
            _friends = new List<User>();
            if (!Validate())
            {
                throw new ArgumentException("Invalid argument in constructor of User!");
            }
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

        public List<Wallet> MyWallets
        {
            get { return _myWallets; }
        }

        public List<Wallet> OtherWallets
        {
            get { return _otherWallets; }
        }

        public List<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }

        public List<User> Friends
        {
            get { return _friends; }
            set { _friends = value; }
        }

        public int CategoriesAmount()
        {
            return _categories.Count;
        }
       
        private Wallet FindWallet(int walletId)
        {
            if (IsValidId(walletId))
            {
                foreach (var wallet in MyWallets)
                {
                    if (wallet.Id == walletId)
                    {
                       // Console.WriteLine("+");
                        return wallet;
                    }
                }
                Console.WriteLine("The wallet is not found");
            }
            return null;
        }

        public void AddTransaction(Wallet wallet, Transaction transaction)
        {
            bool permitChanges = false;
            if (wallet.Owner == this)
                permitChanges = true;

            if (permitChanges == false)
            {
                foreach(var w in OtherWallets)
                {
                    if (wallet.Equals(w))
                    {
                        permitChanges = true;
                        break;
                    }
                }
            }

            if (permitChanges == true)
            {
                foreach (var t in wallet.Transactions)
                {
                    if (t.Id == transaction.Id)
                    {
                        Console.WriteLine("Transaction with this id already exists!");
                        return;
                    }
                }
                //if (!(Categories.Contains(transaction.Category)))
                //{
                //    Console.WriteLine("Transaction with unknown Category can't be added!");
                //    //Console.WriteLine(transaction.Category.ToString());
                //    //Console.WriteLine();
                //    //ShowCategories();
                //    return;
                //}
                if (!wallet.IsAvailable(transaction.Category))
                {
                    Console.WriteLine("Category of the transaction is unavailable. "
                                      + "Transaction can't be added!");
                    return;
                }
                wallet.Transactions.Add(transaction);
                wallet.CurrentBalance += TransformCurrency(transaction.Currency, wallet.MainCurrency, transaction.Sum);
                Console.WriteLine("The transaction was added successfully");
            }
            else
            {
                Console.WriteLine("The transaction was not added");
            }
        }

        public void AddFriend(User friend, int i)
        {
            foreach (var f in Friends)
            {
                if (friend.Equals(f))
                {
                    Console.WriteLine("The friend is already added");
                    return;
                }
            }
           Friends.Add(friend);
           friend.OtherWallets.Add(FindWallet(i));
           Console.WriteLine("The friend was added successfully");
        }

        public void ShowFriends()
        {
            foreach (var friends in Friends)
            {
                    Console.WriteLine(friends);
                    return;
            }
        }

        public void ShowOtherWallets()
        {
            foreach (var wallet in OtherWallets)
            {
                Console.WriteLine(wallet);
                return;
            }
        }

        public void ShowMyWallets()
        {
            foreach (var wallet in MyWallets)
            {
                Console.WriteLine(wallet);
                return;
            }
        }

        public void ShowCategories()
        {
            foreach (var category in Categories)
            {
                Console.WriteLine(category);
                return;
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

            if (Id <= 0)
                result = false;
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
    }
}
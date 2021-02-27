using System;
using System.Collections.Generic;

namespace ControlSpending
{
    public class User
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
    }
}
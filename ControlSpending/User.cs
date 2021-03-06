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
            set { _categories = value; }
        }

        public int CategoriesAmount()
        {
            return _categories.Count;
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
        
    }
}
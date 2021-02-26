using System;

namespace ControlSpending
{
    public class User
    {
        private string _name;
        private string _surname;
        private string _email;

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
    }
}
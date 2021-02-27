using System;
namespace ControlSpending
{
    public class Transaction
    {
        private string _name;
        private int _sum;
        private string _currency;
        private string _description;
        private DateTime? _date;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Sum
        {
            get { return _sum; }
            set { _sum = value; }
        }

        public string Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public DateTime? Date
        {
            get { return _date; }
            set {  _date = value; }
        }
    }
}
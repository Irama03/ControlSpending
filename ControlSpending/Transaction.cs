using System;
using System.Collections.Generic;
using System.IO;

namespace ControlSpending
{
    // Class Transaction keeps an amount, currency, category, description, date.
    //You can also attach files (images or text) to the transaction.
    public class Transaction : Entity
    {
        private int _id;
        private decimal _sum;
        private string _currency;
        private string _description;
        private DateTime? _date;
        private Category _category;
        // private bool _enableFile = false;
        private List<FileInfo> _files;

        public Transaction()
        {
            _files = new List<FileInfo>();
        }

        public Transaction(int id, decimal sum, string currency, string description, DateTime? date, Category category)
        {
            _id = id;
            _sum = sum;
            _currency = currency;
            _description = description;
            _date = date;
            _category = category;
            _files = new List <FileInfo>();
            if (!Validate())
            {
                throw new ArgumentException("Invalid argument in constructor of Transaction!");
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                if (value <= 0)
                {
                    _id = value;
                }
                else
                {
                    Console.WriteLine("Invalid value of Id!");
                }
            }
        }

        public decimal Sum
        {
            get { return _sum; }
            set { _sum = value; }
        }

        public string Currency
        {
            get { return _currency; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    _currency = value;
                }
                else
                {
                    Console.WriteLine("Invalid value of Currency!");
                }
            }
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

        public DateTime? Date
        {
            get { return _date; }
            set {  _date = value; }
        }

        public Category Category
        {
            get { return _category; }
            set
            {
                if (value != null)
                {
                    _category = value;
                }
                else
                {
                    Console.WriteLine("Invalid value of Category!");
                }
            }
        }

        public List<FileInfo> Files
        {
            get { return _files; }
            set { _files = value; }
        }

        //public bool EnableFile
        //{
        //    get { return _enableFile; }
        //    set { _enableFile = value; }
        //}

        //private void AddFile(string path)
        //{
        //    if (EnableFile == false) { EnableFile = true; }
        //    FileInfo fileInfo = new FileInfo(path);
        //}
        private void AddFile(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            _files.Add(fileInfo);
        }

        public override bool Validate()
        {
            var result = true;

            if (Id <= 0)
                result = false;
            if (String.IsNullOrWhiteSpace(Currency))
                result = false;
            if (String.IsNullOrWhiteSpace(Description))
                result = false;
            if (Date == null)
                result = false;
            if (Category == null)
                result = false;

            return result;
        }

        public override string ToString()
        {
            return $"{Id}, {Sum}, {Currency}, {Description}, {Date}";
        }
    }
}
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
        private double _sum;
        private string _currency;
        private string _description;
        private DateTime? _date;
        // private bool _enableFile = false;
        private List<FileInfo> _files;

        public Transaction()
        {
            _files = new List<FileInfo>();
        }

        public Transaction(int id, double sum, string currency, string description, DateTime? date)
        {
            _id = id;
            _sum = sum;
            _currency = currency;
            _description = description;
            _date = date;
            _files = new List <FileInfo>();
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public double Sum
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

            return result;
        }

        public override string ToString()
        {
            return $"{Id}, {Sum}, {Currency}, {Description}, {Date}";
        }
    }
}
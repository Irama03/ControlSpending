namespace ControlSpending
{
    //Гаманець. Повинен зберігати назву, початковий баланс гаманцю, опис та
    //основну валюту. До нього додаються транзакції. Для кожного гаманця можна
    //вказати список категорій, який доступний в ньому для транзакцій.
    public class Wallet
    {
        private string _name;
        private double _initialBalance;
        private string _description;
        private string _mainCurrency;
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public double InitialBalance
        {
            get { return _initialBalance; }
            set { _initialBalance = value; }
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
        
        public override string ToString()
        {
            return $"{Name}, {InitialBalance}, {Description}, {MainCurrency}";
        }
    }
}
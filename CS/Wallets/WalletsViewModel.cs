using System.Collections.ObjectModel;
using CSharp.ControlSpending.Services;
using Prism.Mvvm;

namespace CSharp.ControlSpending.CS.Wallets
{
    public class WalletsViewModel : BindableBase, IMainNavigatable
    {
        private WalletService _service;
        private Wallet _currentWallet;
        public ObservableCollection<Wallet> Wallets { get; set; }

        public Wallet CurrentWallet
        {
            get
            {
                return _currentWallet;
            }
            set
            {
                _currentWallet = value;
                RaisePropertyChanged();
            }
        }

        public WalletsViewModel()
        {
            _service = new WalletService();
            Wallets = new ObservableCollection<Wallet>(_service.GetWallets());
        }


        public MainNavigatableTypes Type
        {
            get
            {
                return MainNavigatableTypes.Wallets;
            }
        }
        public void ClearSensitiveData()
        {

        }
    }
}
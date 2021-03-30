using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlSpending.Services;
using ControlSpending.Wallet;
using Prism.Mvvm;

namespace ControlSpendingWPF.Wallets
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
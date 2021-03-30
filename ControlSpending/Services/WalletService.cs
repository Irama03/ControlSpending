using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ControlSpending.Services
{
    public class WalletService
    {
        private static List<Wallet0> Users = new List<Wallet0>()
        {
            new Wallet0() {Name = "wal1", Balance = 57.06m},
            new Wallet0() {Name = "wal2", Balance = 157.06m},
            new Wallet0() {Name = "wal3", Balance = 257.06m},
            new Wallet0() {Name = "wal4", Balance = 357.06m},
            new Wallet0() {Name = "wal5", Balance = 457.06m},
        };

        public List<Wallet0> GetWallets()
        {
            return Users.ToList();
        }
    }
}
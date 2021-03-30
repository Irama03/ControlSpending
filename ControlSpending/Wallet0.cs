using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlSpending
{
    public class Wallet0
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Balance})";
        }
    }
}
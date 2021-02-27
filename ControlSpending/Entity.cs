using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlSpending
{
    public abstract class Entity
    {
        public abstract bool Validate();

        public bool IsValid
        {
            get { return Validate(); }
        }
    }
}

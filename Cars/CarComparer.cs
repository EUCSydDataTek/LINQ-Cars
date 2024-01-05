using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    internal class CarComparer : IEqualityComparer<Car>
    {

        public bool Equals(Car x, Car y)
        {
            if (string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(Car obj)
        {
            return obj.Name.GetHashCode();
        }

    }
}

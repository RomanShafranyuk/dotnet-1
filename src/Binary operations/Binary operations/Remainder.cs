using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_operations
{
    internal class Remainder : Operations
    {
        public Numbers nums;

        public Remainder() { }

        public Remainder(Numbers n)
        {
            nums = n;
        }

        public override int Get_result()
        {
            return nums.rhs % nums.lhs;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_operations
{
    internal class Multyplication : Operations
    {
        public Numbers nums;

        public Multyplication() { }

        public Multyplication(Numbers n)
        {
            nums = n;
        }

        public override int Get_result()
        {
            return nums.rhs * nums.lhs;
        }
    }
}

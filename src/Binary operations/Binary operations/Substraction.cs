using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_operations
{
    internal class Substraction : Operations
    {
        public Numbers nums;

        public Substraction() { }

        public Substraction(Numbers n)
        {
            nums = n;
        }
        public override int Get_result()
        {
            return nums.lhs - nums.rhs;
        }
    }
}

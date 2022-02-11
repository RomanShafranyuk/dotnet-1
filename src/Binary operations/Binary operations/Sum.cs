using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_operations
{
    internal class Sum : Operations
    {
        public Numbers nums;

        public Sum() { }

        public Sum(Numbers n) {
            nums = n;
        }
        public override int Get_result()
        {
            return nums.rhs + nums.lhs;
        }
    }
}

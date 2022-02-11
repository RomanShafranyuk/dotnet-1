using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_operations
{
    internal class Division : Operations
    {
        public Numbers nums;

        public Division() { }

        public Division(Numbers n)
        {
            nums = n;
        }

        public override int Get_result()
        {
            // навесить исключение 
            return nums.rhs / nums.lhs;
        }
    }
}

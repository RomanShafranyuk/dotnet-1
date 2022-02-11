using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_operations
{
    internal struct Numbers
    {
        public int lhs;
        public int rhs;

        public Numbers(int left, int right) { lhs = left; rhs = right; }

        public void change_left_number(int left) {
            lhs = left;
        }

    }
}

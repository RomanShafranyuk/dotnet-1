using System;
using System.Collections.Generic;
using System.Linq;

namespace Binary_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            var nums = new Numbers(1, 2);
            Operations sum = new Sum(nums);
            Operations sub = new Substraction(nums);
            List<Operations> operations = new() { sub, sum };
            Console.WriteLine(operations.Min(operation => operation.Get_result()));
            //Console.WriteLine(sub.Get_result());
        }
    }
}

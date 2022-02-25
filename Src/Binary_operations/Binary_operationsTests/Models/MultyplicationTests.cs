﻿using Xunit;
namespace Binary_operations.Models.Tests
{
    
    public class MultyplicationTests
    {
        [Fact]
        public void GetResultTest()
        {
            var obj1 = new Multyplication(10, 2);
            var executed = 20;
            var actual = obj1.GetResult(obj1.Lhs,obj1.Rhs);
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void EqualsTest()
        {
            var obj1 = new Multyplication(1, 2);
            var obj2 = new Multyplication(1, 2);
            var executed = true;
            var actual = obj1.Equals(obj2);
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var obj1 = new Multyplication(1, 2);
            var executed = "test";
            var actual = obj1.ToString();
            Assert.Equal(executed.GetType(), actual.GetType());
        }
    }
}
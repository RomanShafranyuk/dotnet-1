using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binary_operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_operations.Tests
{
    [TestClass]
    public class AdditionTests
    {
        [TestMethod]
        public void GetResultTest()
        {
            //arrange 
            var expected = 3;
            var test_data1 = new Addition(1, 2);
            //act
            int actual = test_data1.GetResult();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var test = new Addition(1, 2);
            var actual = test.ToString();
            var expected = "test";
            Assert.AreEqual(expected.GetType(), actual.GetType());


        }

        [TestMethod()]
        public void EqualsTest()
        {
            var obj1 = new Addition(1, 2);
            var obj2 = new Addition(1, 3);
            var expected = false;
            var actual = obj1.Equals(obj2);
            Assert.AreEqual(expected, actual);
        }
    }
}
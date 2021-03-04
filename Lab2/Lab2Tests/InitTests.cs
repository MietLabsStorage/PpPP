using System;
using static System.Console;
using NUnit.Framework;
using Lab2;

namespace lab2tests
{
    [TestFixture]
    public class InitTests
    {
        [Test]
        public void Test1()
        {
            double a, b, c, d, e, f;
            bool succes;
            try
            {
                (a, b, c, d, e, f) = Program.Init("1", "2", "3", "4", "5", "6");
                succes = Tuple.Equals((1.0, 2.0, 3.0, 4.0, 5.0, 6.0), (a, b, c, d, e, f));
            }
            catch
            {
                succes = false;
            }

            Assert.True(succes);
        }

        [Test]
        public void Test2()
        {
            double a, b, c, d, e, f;
            bool succes;
            try
            {
                (a, b, c, d, e, f) = Program.Init("a", "b", "c", "d", "e", "f");
                succes = true;
            }
            catch
            {
                succes = false;
            }

            Assert.True(succes);
        }

        [Test]
        public void Test3()
        {
            double a, b, c, d, e, f;
            bool succes;
            try
            {
                (a, b, c, d, e, f) = Program.Init("0,1", "0,2", "0,3", "0,4", "0,5", "0,6");
                succes = Tuple.Equals((0.1, 0.2, 0.3, 0.4, 0.5, 0.6), (a, b, c, d, e, f));
            }
            catch
            {
                succes = false;
            }

            Assert.True(succes);
        }

        [Test]
        public void Test4()
        {
            double a, b, c, d, e, f;
            bool succes;
            try
            {
                (a, b, c, d, e, f) = Program.Init("0.1", "0.2", "0.3", "0.4", "0.5", "0.6");
                succes = Tuple.Equals((0.1, 0.2, 0.3, 0.4, 0.5, 0.6), (a, b, c, d, e, f));
            }
            catch
            {
                succes = false;
            }

            Assert.True(succes);
        }
    }
}
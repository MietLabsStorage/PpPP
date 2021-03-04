using System;
using static System.Console;
using NUnit.Framework;
using Lab2;

namespace lab2tests
{
    [TestFixture]
    public class SolveTests
    {
        [Test]
        public void Test01()
        {
            string ans = Program.Solve(0, 0, 0, 0, 0, 0);
            Assert.True(String.Equals("5", ans));
        }

        [Test]
        public void Test02()
        {
            string ans = Program.Solve(0, 0, 0, 1, 0, 2);
            Assert.True(String.Equals($"4 {2}", ans));
        }

        [Test]
        public void Test03()
        {
            string ans = Program.Solve(0, 2, 0, 0, 5, 0);
            Assert.True(String.Equals($"4 {2.5}", ans));
        }

        [Test]
        public void Test04()
        {
            string ans = Program.Solve(1, 0, 0, 0, 2, 0);
            Assert.True(String.Equals($"3 {2}", ans));
        }

        [Test]
        public void Test05()
        {
            string ans = Program.Solve(2, 0, 0, 0, 5, 0);
            Assert.True(String.Equals($"3 {2.5}", ans));
        }


        [Test]
        public void Test07()
        {
            string ans = Program.Solve(2, 3, 3, 2, 8, 7);
            Assert.True(String.Equals($"2 {1} {2}", ans));
        }

        [Test]
        public void Test08()
        {
            string ans = Program.Solve(100, 1, 1, 100, 1, 100);
            Assert.True(String.Equals($"2 {0} {1}", ans));
        }

        [Test]
        public void Test09()
        {
            string ans = Program.Solve(100, 1, 1, 100, 100, 1);
            Assert.True(String.Equals($"2 {1} {0}", ans));
        }

        [Test]
        public void Test10()
        {
            string ans = Program.Solve(100, 100, 100, 100, 0, 0);
            Assert.True(String.Equals($"1 {-1} {0}", ans));
        }

        [Test]
        public void Test11()
        {
            string ans = Program.Solve(100, 0, 100, 100, 0, 0);
            Assert.True(String.Equals($"2 {0} {0}", ans));
        }

        [Test]
        public void Test12()
        {
            string ans = Program.Solve(100, 100, 100, 0, 0, 0);
            Assert.True(String.Equals($"2 {0} {0}", ans));
        }

        [Test]
        public void Test13()
        {
            string ans = Program.Solve(0, 100, 100, 100, 0, 0);
            Assert.True(String.Equals($"2 {0} {0}", ans));
        }

        [Test]
        public void Test14()
        {
            string ans = Program.Solve(100, 100, 0, 100, 0, 0);
            Assert.True(String.Equals($"2 {0} {0}", ans));
        }
        
        [Test]
        public void Test15()
        {
            string ans = Program.Solve(0, 0, 100, 100, 0, 0);
            Assert.True(String.Equals($"1 {-1} {0}", ans));
        }

        [Test]
        public void Test16()
        {
            string ans = Program.Solve(100, 100, 0, 0, 0, 0);
            Assert.True(String.Equals($"1 {-1} {0}", ans));
        }
        
    }
}
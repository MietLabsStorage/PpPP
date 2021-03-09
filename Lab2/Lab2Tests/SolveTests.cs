using System;
using static System.Console;
using NUnit.Framework;
using Lab2;

namespace lab2tests
{
    [TestFixture]
    public class SolveTests
    {
        //***************************************************************************
        //* Любая пара чисел является решение если уравнение отсутсвует,
        //* т.е. все коэф - 0
        //***************************************************************************
        [Test]
        public void Test5_01()
        {
            string ans = Program.Solve(0, 0, 0, 0, 0, 0);
            Assert.AreEqual("5", ans);
        }


        //***************************************************************************
        //* Единственное решени достигается при det != 0
        //* det1 и det2 могут быть любыми
        //***************************************************************************
        
        /// <summary>
        /// det, det1, det2 != 0
        /// </summary>
        [Test]
        public void Test2_01_i()
        {
            string ans = Program.Solve(1, 2, 3, 1, 3, 4);
            Assert.AreEqual($"2 {1} {1}", ans);
        }
        [Test]
        public void Test2_01_d()
        {
            string ans = Program.Solve(1.1, 2.2, 3.3, 1.1, 3, 4);
            Assert.AreEqual($"2 {10/11.0} {10/11.0}", ans);
        }
        
        /// <summary>
        /// det, det1 != 0, det2 = 0
        /// </summary>
        [Test]
        public void Test2_02_i()
        {
            string ans = Program.Solve(1, 2, 2, 1, -1, -2);
            Assert.AreEqual($"2 {-1} {0}", ans);
        }
        [Test]
        public void Test2_02_d()
        {
            string ans = Program.Solve(1.1, 2, 2.2, 1, -1, -2);
            Assert.AreEqual($"2 {-10/11.0} {0}", ans);
        }
        
        /// <summary>
        /// det, det2 != 0, det1 = 0
        /// </summary>
        [Test]
        public void Test2_03_i()
        {
            string ans = Program.Solve(1, 2, 2, 1, -2, -1);
            Assert.AreEqual($"2 {0} {-1}", ans);
        }
        [Test]
        public void Test2_03_d()
        {
            string ans = Program.Solve(1, 2.2, 2, 1.1, -2, -1);
            Assert.AreEqual($"2 {0} {-10/11.0}", ans);
        }
        
        /// <summary>
        /// det != 0, det1, det2 = 0
        /// </summary>
        [Test]
        public void Test2_04()
        {
            string ans = Program.Solve(1, 0, 0, 1, 0, 0);
            Assert.AreEqual($"2 {0} {0}", ans);
        }
        
        
        
        //***************************************************************************
        //* x = x0, y - any
        //* достигается при виде qx = p
        //***************************************************************************
        
        /// <summary>
        ///  ax = e
        /// </summary>
        /// [Test]
        [Test]
        public void Test3_01_i()
        {
            string ans = Program.Solve(0.5, 0, 0,0, 1, 0);
            Assert.AreEqual($"3 {2}", ans);
        }
        [Test]
        public void Test3_01_d()
        {
            string ans = Program.Solve(0.5, 0, 0,0, 1/3.0, 0);
            Assert.AreEqual($"3 {2/3.0}", ans);
        }
        
        /// <summary>
        ///  cx = f
        /// </summary>
        [Test]
        public void Test3_02_i()
        {
            string ans = Program.Solve(0, 0, 0.5,0, 0, 1);
            Assert.AreEqual($"3 {2}", ans);
        }
        [Test]
        public void Test3_02_d()
        {
            string ans = Program.Solve(0, 0, 0.5,0, 0, 1/3.0);
            Assert.AreEqual($"3 {2/3.0}", ans);
        }
        
        /// <summary>
        ///  ax = e and cx = f
        /// </summary>
        [Test]
        public void Test3_03_i()
        {
            string ans = Program.Solve(0.5, 0, 0.5,0, 1, 1);
            Assert.AreEqual($"3 {2}", ans);
        }
        [Test]
        public void Test3_03_d()
        {
            string ans = Program.Solve(0.5, 0, 0.5,0, 1/3.0, 1/3.0);
            Assert.AreEqual($"3 {2/3.0}", ans);
        }
        
        
        //***************************************************************************
        //* y = y0, x - any
        //* достигается при виде qx = p
        //***************************************************************************
        
        /// <summary>
        ///  ax = e
        /// </summary>
        [Test]
        public void Test4_01_i()
        {
            string ans = Program.Solve(0, 0.5, 0,0, 1, 0);
            Assert.AreEqual($"4 {2}", ans);
        }
        [Test]
        public void Test4_01_d()
        {
            string ans = Program.Solve(0, 0.5, 0,0, 1/3.0, 0);
            Assert.AreEqual($"4 {2/3.0}", ans);
        }
        
        /// <summary>
        ///  cx = f
        /// </summary>
        [Test]
        public void Test4_02_i()
        {
            string ans = Program.Solve(0, 0, 0,0.5, 0, 1);
            Assert.AreEqual($"4 {2}", ans);
        }
        [Test]
        public void Test4_02_d()
        {
            string ans = Program.Solve(0, 0, 0,0.5, 0, 1/3.0);
            Assert.AreEqual($"4 {2/3.0}", ans);
        }
        
        /// <summary>
        ///  ax = e and cx = f
        /// </summary>
        [Test]
        public void Test4_03_i()
        {
            string ans = Program.Solve(0, 0.5, 0, 0.5, 1, 1);
            Assert.AreEqual($"4 {2}", ans);
        }
        [Test]
        public void Test4_03_d()
        {
            string ans = Program.Solve(0, 0.5, 0, 0.5, 1/3.0, 1/3.0);
            Assert.AreEqual($"4 {2/3.0}", ans);
        }
        
        //***************************************************************************
        //* y = kx + n
        //* достигается при виде qx+py=w
        //***************************************************************************
        
        /// <summary>
        ///  0x+0y=0 and cx+fy=f
        /// </summary>
        [Test]
        public void Test1_01_i()
        {
            string ans = Program.Solve(0, 0, 1, 1, 0, 1);
            Assert.AreEqual($"1 {-1} {1}", ans);
        }
        [Test]
        public void Test1_01_d()
        {
            string ans = Program.Solve(0, 0, 2/3.0, 1, 0, 2/3.0);
            Assert.AreEqual($"1 {-2/3.0} {2/3.0}", ans);
        }
        
        /// <summary>
        ///  ax+by=e and 0x+0y=0
        /// </summary>
        [Test]
        public void Test1_02_i()
        {
            string ans = Program.Solve(1, 1, 0, 0, 1, 0);
            Assert.AreEqual($"1 {-1} {1}", ans);
        }
        [Test]
        public void Test1_02_d()
        {
            string ans = Program.Solve(2/3.0, 1, 0, 0, 2/3.0, 0);
            Assert.AreEqual($"1 {-2/3.0} {2/3.0}", ans);
        }
        
        /// <summary>
        ///  ax+by=e and kax+kby=ke
        /// </summary>
        [Test]
        public void Test1_03_i()
        {
            string ans = Program.Solve(1, 1, 3, 3, 1, 3);
            Assert.AreEqual($"1 {-1} {1}", ans);
        }
        [Test]
        public void Test1_03_d()
        {
            string ans = Program.Solve(2/3.0, 1, 2, 3, 2/3.0, 2);
            Assert.AreEqual($"1 {-2/3.0} {2/3.0}", ans);
        }
        
       
        
        //***************************************************************************
        //* нет решений
        //* при det = 0
        //***************************************************************************
        
        /// <summary>
        /// a = b = c = d != 0
        /// </summary>
        [Test]
        public void Test0_01()
        {
            string ans = Program.Solve(3, 3, 3, 3, 2, 4);
            Assert.AreEqual($"0", ans);
        }
        
        /// <summary>
        /// a = b = c = d = 0
        /// </summary>
        [Test]
        public void Test0_02()
        {
            string ans = Program.Solve(0, 0, 0, 0, 2, 4);
            Assert.AreEqual($"0", ans);
        }
        
        /// <summary>
        /// a*d = c*b
        /// </summary>
        [Test]
        public void Test0_03()
        {
            string ans = Program.Solve(1, 2, 1, 2, 2, 4);
            Assert.AreEqual($"0", ans);
        }

    }
}
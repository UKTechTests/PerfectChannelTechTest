using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Eviivo.Domain.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string text = "Polly put the kettle on, Polly put the kettle on, Polly put the kettle on we’ll all have tea";
            string subText = "Polly";
            IList<int> a = new Class1().Match(text, subText);

            Assert.AreEqual(a[0],1);
            Assert.AreEqual(a[1], 26);
            Assert.AreEqual(a[2], 51);
        }

        [TestMethod]
        public void TestMethod12()
        {
            string text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";
            string subText = "ll(ell ell)";
            IList<int> a = new Class1().Match(text, subText);

            Assert.AreEqual(a[0], 3);
            Assert.AreEqual(a[1], 28);
            Assert.AreEqual(a[2], 53);
            Assert.AreEqual(a[3], 78);
            Assert.AreEqual(a[4], 82);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData.UnitTest
{
    [TestClass]
    public class BoundedIntTestFixture
    {
        [TestMethod]
        public void CtorTest()
        {
            BoundedInt value = new BoundedInt(0, 99);

            value.Value = 50;

            Assert.AreEqual(50, value);
        }

        [TestMethod]
        public void InitialValueTest()
        {
            BoundedInt value = new BoundedInt(50, 99);

            Assert.AreEqual(50, value);
        }

        [TestMethod]
        [ExcludeFromCodeCoverage]
        [ExpectedException(typeof(FormatException))]
        public void ValueTooSmall()
        {
            BoundedInt value = new BoundedInt(0, 99);

            value.Value = -1;
        }

        [TestMethod]
        [ExcludeFromCodeCoverage]
        [ExpectedException(typeof(FormatException))]
        public void ValueTooBig()
        {
            BoundedInt value = new BoundedInt(0, 99);

            value.Value = 100;
        }
    }
}

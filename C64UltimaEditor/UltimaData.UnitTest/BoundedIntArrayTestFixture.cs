using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData.UnitTest
{
    [TestClass]
    public class BoundedIntArrayTestFixture
    {
        [TestMethod]
        public void CtorTest()
        {
            BoundedIntArray array = new BoundedIntArray(5, 0, 99);

            array[2] = 50;

            Assert.AreEqual(50, array[2]);
        }

        [TestMethod]
        [ExcludeFromCodeCoverage]
        [ExpectedException(typeof(FormatException))]
        public void ValueTooSmall()
        {
            BoundedIntArray array = new BoundedIntArray(5, 0, 99);

            array[2] = -1;
        }

        [TestMethod]
        [ExcludeFromCodeCoverage]
        [ExpectedException(typeof(FormatException))]
        public void ValueTooBig()
        {
            BoundedIntArray array = new BoundedIntArray(5, 0, 99);

            array[2] = 100;
        }

        [TestMethod]
        [ExcludeFromCodeCoverage]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexOutOfRange()
        {
            BoundedIntArray array = new BoundedIntArray(5, 0, 99);

            array[5] = 50;
        }

        [TestMethod]
        public void Enumerable()
        {
            BoundedIntArray array = new BoundedIntArray(5, 0, 99);

            foreach(var i in array)
            {
                Assert.AreEqual(0, i);
            }

            IEnumerable weak = array.AsWeakEnumerable();
            var sequence = weak.Cast<int>().ToArray();
            CollectionAssert.AreEqual(sequence, new[] { 0, 0, 0, 0, 0 });
        }
    }




}

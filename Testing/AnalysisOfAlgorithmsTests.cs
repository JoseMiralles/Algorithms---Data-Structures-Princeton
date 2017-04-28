using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using static Algorithms.AnalysisOfAlgorithms;

namespace Testing
{
    [TestClass]
    public class AnalysisOfAlgorithmsTests
    {
        [TestMethod]
        [TestCategory("ThreeSum")]
        public void ThreeSumTest8()
        {
            ThreeSumm.Count(ThreeSumm.ints8);
        }
        [TestMethod]
        [TestCategory("ThreeSum")]
        public void ThreeSumTest19()
        {
            ThreeSumm.Count(ThreeSumm.ints19);
        }
        [TestMethod]
        [TestCategory("ThreeSum")]
        public void ThreeSumTest38()
        {
            ThreeSumm.Count(ThreeSumm.ints38);
        }

        [TestMethod]
        [TestCategory("Search")]
        public void TestBinarySearchTest()
        {
            int target = 97;
            int answer = 14;
            int result = BinarySearch.TestBinarySearch(target, BinarySearch.ints);
            Assert.AreEqual(answer, result);
        }
    }
}

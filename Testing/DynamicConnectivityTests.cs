using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Algorithms.DynamicConnectivity;
using static Algorithms.AnalysisOfAlgorithms;

namespace Testing
{
    //[TestClass]
    //public class ExampleTestClass
    //{
    //    [TestMethod]
    //    //[Ignore]    // Ignore the test
    //    [TestCategory("Example")] //Asigned a category
    //    [Priority(-1)] //Adds a priority to the test
    //    public void ExampleTest()
    //    {
    //        int answer = 2; //Intended Answer
    //        int result = 1 + 2; //Result will equal 3
    //        Assert.AreEqual(answer, result); //This fails on purpose
    //    }
    //}

    [TestClass]
    public class UnionfindTests
    {
        [TestMethod]
        [TestCategory("UnionFind")]
        public void QuickFindTest()
        {
            var UF = new QuickFindUF(Algorithms.DynamicConnectivity.length);
            Run(UF, Algorithms.DynamicConnectivity.commands);
        }

        [TestMethod]
        [TestCategory("UnionFind")]
        public void QuickUnionTest()
        {
            var UF = new QuickUnionUF(Algorithms.DynamicConnectivity.length);
            Run(UF, Algorithms.DynamicConnectivity.commands);
        }

        [TestMethod]
        [TestCategory("UnionFind")]
        public void QuickUnionWeightedTest()
        {
            var UF = new QuickUnionUFWeighted(Algorithms.DynamicConnectivity.length);
            Run(UF, Algorithms.DynamicConnectivity.commands);
        }
    }
}

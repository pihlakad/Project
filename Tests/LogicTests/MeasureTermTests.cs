﻿using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests
{
    [TestClass]
    public class MeasureTermTests: CommonTests<MeasureTerm>
    
    {
        [TestMethod]

        protected override MeasureTerm getRandomObj() {
            return MeasureTerm.Random();
        }

        private MeasureTerm b;
        [TestInitialize]
        public void InitTests()
        {
            b = new MeasureTerm();
        }
        [TestCleanup]
        public void CleanTests()
        {
            b = null;
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(b);
        }
    }
}

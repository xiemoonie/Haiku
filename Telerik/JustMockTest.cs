using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomHaikuGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;

namespace Telerik
{
    /// <summary>
    /// Summary description for JustMockTest
    /// </summary>
    [TestClass]
    public class JustMockTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        public Dictionary<string, int> GetTestProducts() {
            return new Dictionary<string, int>(){
            {"skirt", 1},
            {"pants", 2},
            {"glasses",3}
            };
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod()
        {
            Order o = new Order("Lamp", 10);
            Warehouse w = new Warehouse();
            Mock.Arrange(() => w.HasInventory(o.ProductName, o.Quantity)).Returns(true);
            Mock.Arrange(() => w.RemoveInventory(o.ProductName, o.Quantity)).DoNothing();

            o.Completed(w);
            Assert.IsTrue(o.isCompleted);
        }

        [TestMethod]
        public void TestMethodTestProduct()
        {
            Order o = new Order("skirt", 1);
            Warehouse w = new Warehouse();
            Mock.Arrange(() => w.Product).Returns(this.GetTestProducts());
            o.Completed(w);
            Assert.IsTrue(o.isCompleted);
            
        }

        [TestMethod]
        public void TestWeatherResponse()
        {
           // Weather w = new Weather();
            var we = Mock.Create<Weather>();
            Mock.Arrange(() => we.PrintResult("")).Returns(true);
            Assert.AreEqual(we.PrintResult(""), true);
        }
    }
}



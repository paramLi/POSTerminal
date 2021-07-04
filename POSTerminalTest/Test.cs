
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POSTerminal;
using POSTerminal.Model;
using POSTerminal.Service;

namespace POSTerminalTest
{
    [TestClass]
    public class Utest
    {
        private PointOfSaleTerminal _posTerminal;

        [TestInitialize()]
        public void TestInitialize()
        {
            _posTerminal = new PointOfSaleTerminal();

            var productA = new Product('A', 1.25);
            _posTerminal.SetPricing(productA);
            _posTerminal.SetCalculationRequest(new BulkCalculateService(3, 3.00, productA));

            var productB = new Product('B', 4.25);
            _posTerminal.SetPricing(productB);

            var productC = new Product('C', 1.00);
            _posTerminal.SetPricing(productC);
            _posTerminal.SetCalculationRequest(new BulkCalculateService(6, 5.00, productC));

            var productD = new Product('D', 0.75);
            _posTerminal.SetPricing(productD);

            _posTerminal.SetCalculationRequest(new SingleCalculateService());
        }

        [TestMethod]
        public void TestCase1()
        {
            _posTerminal.Scan("ABCDABA");

            Assert.AreEqual(13.25, _posTerminal.CalculateTotal());
        }

        [TestMethod]
        public void TestCase2()
        {
            _posTerminal.Scan("CCCCCCC");

            Assert.AreEqual(6.00, _posTerminal.CalculateTotal());
        }

        [TestMethod]
        public void TestCase3()
        {
            _posTerminal.Scan("ABCD");

            Assert.AreEqual(7.25, _posTerminal.CalculateTotal());
        }

        
    }
}

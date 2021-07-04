using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POSTerminal;
using POSTerminal.Model;

namespace POSTerminalTest
{
    public class ExpectionTest
    {
        /// <summary>
        /// Test Exception - Product already sxists
        /// </summary>
        [TestMethod]
        public void SetPricing_ProductAlreadyExist()
        {
            // arrange
            var posTerminal = new PointOfSaleTerminal();
            posTerminal.SetPricing(new Product('A', 1));

            // act
            // assert
            posTerminal.SetPricing(new Product('A', 2));
        }

        /// <summary>
        /// Test Exception - Product Not Found
        /// </summary>
        [TestMethod]
        public void Scan_ProductNotFound()
        {
            var posTerminal = new PointOfSaleTerminal();

            posTerminal.Scan("A");
        }
    }
}

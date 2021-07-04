using System;
using System.Collections.Generic;

namespace POSTerminal.Model
{
    /// <summary>
    /// Product Model
    /// </summary>
    public class Product
    {
        public char Code { get; }
        public double Price { get; }

        public Product(char code, double price)
        {
            Code = code;
            Price = price;
        }
    }

    /// <summary>
    /// ScannedProduct Model
    /// </summary>
    public class ScannedProduct
    {
        public Product Product { set; get; }
        public int Count { set; get; }
    }

    /// <summary>
    /// Calculation Model
    /// </summary>
    public class CalculationRequest
    {
        public List<ScannedProduct> NotCalculatedProducts { get; }

        public double TotalPrice { get; set; } = 0;

        public CalculationRequest(List<ScannedProduct> scannedProduct)
        {
            NotCalculatedProducts = scannedProduct;
        }
    }

}
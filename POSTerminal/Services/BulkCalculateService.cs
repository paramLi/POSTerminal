using System;
using System.Linq;
using POSTerminal.Model;

namespace POSTerminal.Service
{
    public class BulkCalculateService : RequestHandler
    {
        private int _quantity { get; }
        private double _price { get; }
        public Product Product { get; }

        public BulkCalculateService(int quantity, double price, Product product)
        {
            _quantity = quantity;
            _price = price;
            Product = product;
        }

        /// <summary>
        /// Calculate total price of bulk products
        /// </summary>
        /// <param name="requestOrder"></param>
        public void CalculatePrice(CalculationRequest requestOrder)
        {
            var productsOrder = requestOrder.NotCalculatedProducts.FirstOrDefault(x => x.Product == Product);

            if (productsOrder?.Count >= _quantity)
            {
                productsOrder.Count = productsOrder.Count - _quantity;
                requestOrder.TotalPrice += _price;
            }
        }
    }
}

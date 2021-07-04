using System;
using System.Collections.Generic;
using System.Linq;
using POSTerminal.Model;
using POSTerminal.Service;

namespace POSTerminal
{
    public class PointOfSaleTerminal
    {
        private List<Product> _products = new List<Product>();
        private List<RequestHandler> _requests = new List<RequestHandler>();

        private string _scannedProduct = string.Empty;

        public void SetPricing(Product product)
        {
            if (_products.Any(x => x.Code == product.Code))
            {
                throw new Exception("Product code already exists");
            }

            _products.Add(product);
        }

        public void Scan(string productCodes)
        {
            productCodes.ToList().ForEach(productCode =>
            {
                if (!_products.Any(x => x.Code == productCode)) throw new Exception("Product Not Found");
                _scannedProduct += productCode;
            });
        }

        public void SetCalculationRequest(RequestHandler request)
        {
            _requests.Add(request);
        }

        public double CalculateTotal()
        {
            var orders = _scannedProduct.GroupBy(x => x)
                .Select(x => new ScannedProduct
                {
                    Product = _products.First(p => p.Code == x.Key),
                    Count = x.Count()
                }).ToList();

            var calculationRequest = new CalculationRequest(orders);
            _requests.ForEach(x => x.CalculatePrice(calculationRequest));

            return calculationRequest.TotalPrice;
        }
    }

}

using System;
using System.Linq;
using POSTerminal.Model;

namespace POSTerminal.Service
{
    public class SingleCalculateService : RequestHandler
    {
        /// <summary>
        /// Calculate Signle Items
        /// </summary>
        /// <param name="request"></param>
        public void CalculatePrice(CalculationRequest request)
        {
            request.TotalPrice += request.NotCalculatedProducts.Select(x => x.Product.Price * x.Count).Sum();
        }
    }
}

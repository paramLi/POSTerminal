using System;
using POSTerminal.Model;

namespace POSTerminal.Service
{
    public interface RequestHandler
    {
        void CalculatePrice(CalculationRequest request);
    }
}



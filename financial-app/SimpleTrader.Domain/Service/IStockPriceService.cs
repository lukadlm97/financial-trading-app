using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Service
{
    public interface IStockPriceService
    {
        Task<double> GetPrice(string symbol);
    }
}

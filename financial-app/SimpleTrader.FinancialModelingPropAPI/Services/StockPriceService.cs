using Newtonsoft.Json;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Service;
using SimpleTrader.FinancialModelingPropAPI.Result;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPropAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        public async Task<double> GetPrice(string symbol)
        {
            using (FinancialMarketPrepHttpClient client = new FinancialMarketPrepHttpClient())
            {
                string uri = "stock/real-time-price/" + symbol;

                StockPriceResult stockPrice = await client.GetAsync<StockPriceResult>(uri);

                if(stockPrice.Price == 0)
                {
                    throw new InvalidSymbolException(symbol);
                }

                return stockPrice.Price;
            }
        }
    }
}

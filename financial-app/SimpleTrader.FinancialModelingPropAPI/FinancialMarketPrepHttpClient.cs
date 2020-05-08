using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPropAPI
{
    public class FinancialMarketPrepHttpClient:HttpClient
    {
        public FinancialMarketPrepHttpClient()
        {
            this.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/");
        }
        public async Task<T> GetAsync<T>(string uri)
        {
            HttpResponseMessage httpResponse = await GetAsync(uri);
            string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonResponse);

        }
    }
}

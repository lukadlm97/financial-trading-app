﻿using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPropAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage httpResponse = await client.GetAsync("https://financialmodelingprep.com/api/v3/majors-indexes/.DJI");
                string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                MajorIndex majorIndex = JsonConvert.DeserializeObject<MajorIndex>(jsonResponse);
                return majorIndex;
            }
        }
    }
}

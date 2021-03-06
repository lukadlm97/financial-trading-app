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
            using(FinancialMarketPrepHttpClient client = new FinancialMarketPrepHttpClient())
            {
                string uri = "majors-indexes/" + GetUriSuffix(indexType);


                MajorIndex majorIndex = await client.GetAsync<MajorIndex>(uri);
                
                majorIndex.Type = indexType;

                return majorIndex;
            }
        }

        private string GetUriSuffix(MajorIndexType indexType)
        {
            switch (indexType)
            {
                case MajorIndexType.DowJones:
                    return ".DJI";
                case MajorIndexType.Nasdaq:
                    return ".IXIC";
                case MajorIndexType.SP500:
                    return ".INX";
                default:
                    throw new Exception("MajorIndexType dose not have a suffix defined.");
            }
        }
    }
}

using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Service.TransactionServices
{
    public class BuyStockService : IBuyStockService
    {
        private readonly IStockPriceService _stockPriceService;
        private readonly IDataService<Account> _accountService;

        public BuyStockService(IStockPriceService stockPriceService, IDataService<Account> accountService)
        {
            _stockPriceService = stockPriceService;
            _accountService = accountService;
        }

        public async Task<Account> BuyStock(Account buyer, string stock, int shares)
        {
            double stockPrice = await _stockPriceService.GetPrice(stock);

            double transactionAmount = stockPrice * shares;

            if(transactionAmount > buyer.Balance)
            {
                throw new InsufficientFundException(buyer.Balance,transactionAmount);
            }

            AssetTransaction assetTransaction = new AssetTransaction()
            {
                Account = buyer,
                Asset = new Asset
                {
                    PricePerShare = stockPrice,
                    Symbol = stock
                },
                DateProcessed = DateTime.Now,
                IsPurchase = true,
                Shares = shares
            };

            buyer.Transactions.Add(assetTransaction);
            buyer.Balance -= transactionAmount;

            await _accountService.Update(buyer.Id, buyer);

            return buyer;
        }

        
    }
}

using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Service;
using SimpleTrader.Domain.Service.TransactionServices;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;
using SimpleTrader.FinancialModelingPropAPI.Services;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleTrader.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async  void OnStartup(StartupEventArgs e)
        {
            //IDataService<User> service = new GenericDataService<User>(new SimpleTraderDbContextFactory());
            //IStockPriceService priceService = new StockPriceService();
            //IBuyStockService buyStockService = new BuyStockService(priceService, acccountService);
            IDataService<Account> dataService = new AccountDataService(new SimpleTraderDbContextFactory());


            //Console.WriteLine(service.Create(new User { Username="asdasd"}));
            dataService.GetAll();
            //await buyStockService.BuyStock(buyer, "T", 2);


            Window window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();

            base.OnStartup(e);
        }
    }
}

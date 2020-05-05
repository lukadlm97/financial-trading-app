using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Service;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<User> usersService = new GenericDataService<User>(new SimpleTraderDbContextFactory());
            
            Console.WriteLine(usersService.Update(3,new User { Username="NewName"}).Result);
            Console.ReadKey();
        }
    }
}

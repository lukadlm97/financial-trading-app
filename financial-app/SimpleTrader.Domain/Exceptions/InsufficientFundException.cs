using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SimpleTrader.Domain.Exceptions
{
    public class InsufficientFundException : Exception
    {
        public double AccountBalance { get; set; }
        public double  RequiredBalance { get; set; }
        public InsufficientFundException(double accountBalance,double requiredBalance)
        {
            AccountBalance = accountBalance;
            RequiredBalance = requiredBalance;
        }

        public InsufficientFundException(double accountBalance, double requiredBalance, string message) : base(message)
        {
            AccountBalance = accountBalance;
            RequiredBalance = requiredBalance;
        }

        public InsufficientFundException(double accountBalance, double requiredBalance, string message, Exception innerException) : base(message, innerException)
        {
            AccountBalance = accountBalance;
            RequiredBalance = requiredBalance;
        }

     
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChequeApplication.Models;
namespace ChequeApplication.Services
{
    public class ChequeService : IChequeService
    {
        public string GetAmountWord(Double amount)
        {
            return string.Empty;
        }

        public bool IsValidCheque(ChequeRequest request, out string message)
        {
            message = string.Empty;

            return true;
        }
    }
}
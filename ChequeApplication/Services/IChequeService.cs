using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChequeApplication.Models;
namespace ChequeApplication.Services
{
    interface IChequeService
    {
        string GetAmountWord(Double amount);

        bool IsValidCheque(ChequeRequest request, out string message);
    }
}

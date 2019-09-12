using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChequeApplication.Models
{
    public class ChequeRequest
    {
        public DateTime ChequeDate { get; set; }

        public string Payee { get; set; }

        public Double Amount { get; set; }
    }
}
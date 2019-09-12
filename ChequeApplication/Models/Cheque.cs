using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChequeApplication.Models
{
    public class Cheque
    {
        public DateTime ChequeDate { get; set; }

        public string Payee { get; set; }

        public Double Amount { get; set; }

        public string AmountText { get; set; }
    }
}
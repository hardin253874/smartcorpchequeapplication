using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChequeApplication.Models;
using ChequeApplication.Services;
namespace ChequeApplication.Controllers
{
    public class ChequeController : BaseAPIController
    {
        [HttpGet]
        [ActionName("test")]
        public HttpResponseMessage Get()
        {
            var cheque = new Cheque();
            return ToJson(cheque);
        }

        [HttpGet]
        [ActionName("error")]
        public HttpResponseMessage Error()
        {
            var cheque = new Cheque();
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid cheque date");
        }

        [HttpPost]
        [ActionName("create")]

        // Post: api/Cheque/create
        public HttpResponseMessage Post([FromBody]ChequeRequest request)
        {
            var chequeService = new ChequeService();
            var message = string.Empty;
            var isValid = chequeService.IsValidCheque(request, out message);
            
            if (isValid){                
                var amountWord = chequeService.GetAmountWord(request.Amount);
                return ToJson(new Cheque() { ChequeDate = request.ChequeDate, Amount = request.Amount, Payee = request.Payee, AmountWord = amountWord });
            }
            else {
                return Request.CreateResponse(HttpStatusCode.BadRequest, message);
            }

        }

        
    }
}

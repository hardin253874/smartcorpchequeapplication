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
            var cheque = new Cheque() { ChequeDate = DateTime.Today, Amount = 100.00, Payee = "John Don", AmountText = "One houndred" };

            return ToJson(cheque);
        }

        
    }
}

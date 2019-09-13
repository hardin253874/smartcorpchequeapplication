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
            var beforeFloatingPoint = (long)Math.Floor(amount);
            var beforeFloatingPointWord = $"{NumberToWords(beforeFloatingPoint)} dollars";

            var afterFloatingPoint = (int) (Math.Round((amount - beforeFloatingPoint) * 100, 0));

            var afterFloatingPointWord = afterFloatingPoint > 0 ? 
                                        $"{SmallNumberToWord(afterFloatingPoint, "")} cents" : 
                                        "";

            return beforeFloatingPoint > 0 && afterFloatingPoint > 0 ? 
                $"{beforeFloatingPointWord} and {afterFloatingPointWord}" :
                (beforeFloatingPoint > 0 ? beforeFloatingPointWord :
                    (afterFloatingPoint > 0 ? afterFloatingPointWord: "zero dollars"));           
        }

        public bool IsValidCheque(ChequeRequest request, out string message)
        {
            message = string.Empty;
            //by Cheques Act 1986 Australian cheques are stale after 15 months by law
            if (request.ChequeDate > DateTime.Today.AddMonths(15) || request.ChequeDate < DateTime.Today.AddMonths(-15)) {
                message =
                    "Please enter a valid cheque date. Australian Cheques are stale after 15 months by law (Cheques Act)";
            } else if (string.IsNullOrEmpty(request.Payee) || request.Payee.Length <= 1) {
                message = "Please enter a valid payee.";
            } else if (request.Amount <= 0 || request.Amount >= 10000000000000.00) {
                message = "Please enter a valid cheque amount.";
            }

            return string.IsNullOrEmpty(message);            
        }

        private string NumberToWords(long number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            var words = "";

            if (number / 1000000000 > 0) {
                words += NumberToWords(number / 1000000000) + " billion, ";
                number %= 1000000000;
            }

            if (number / 1000000 > 0) {
                words += NumberToWords(number / 1000000) + " million, ";
                number %= 1000000;
            }

            if (number / 1000 > 0) {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if (number / 100 > 0) {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            words = SmallNumberToWord(number, words);

            return words.Trim();
        }

        private string SmallNumberToWord(long number, string words)
        {
            if (number <= 0) return words;
            if (words != "") {
                words = words.Trim() + " ";
            }
                

            var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20)
                words += unitsMap[number];
            else {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += "-" + unitsMap[number % 10];
            }
            return words.Trim();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChequeApplication.Services;
using ChequeApplication.Models;
using NUnit.Framework;

namespace ChequeApplication.UnitTests
{
    [TestFixture]
    public class ChequeServiceTests
    {
        private static IEnumerable<TestCaseData> AmountWordTestData()
        {
            yield return new TestCaseData(0.10, "ten cents");
            yield return new TestCaseData(.10, "ten cents");
            yield return new TestCaseData(100.00, "one hundred dollars");
            yield return new TestCaseData(10.00, "ten dollars");
            yield return new TestCaseData(20.00, "twenty dollars");
            yield return new TestCaseData(3.20, "three dollars and twenty cents");
            yield return new TestCaseData(217.20, "two hundred seventeen dollars and twenty cents");
            yield return new TestCaseData(3005000150.65, "three billion five million one hundred fifty dollars and sixty-five cents");
            yield return new TestCaseData(0, "zero dollars");
        }

        private static IEnumerable<TestCaseData> ValidChequeTestData()
        {
            yield return new TestCaseData(new ChequeRequest() { ChequeDate = DateTime.Today, Amount = 100.00, Payee = "John" }, "");
            yield return new TestCaseData(new ChequeRequest() { ChequeDate = DateTime.Today.AddMonths(-16), Amount = 100.00, Payee = "John" }, "Please enter a valid cheque date");
            yield return new TestCaseData(new ChequeRequest() { ChequeDate = DateTime.Today.AddMonths(16), Amount = 100.00, Payee = "John" }, "Please enter a valid cheque date");
            yield return new TestCaseData(new ChequeRequest() { ChequeDate = DateTime.MinValue, Amount = 100.00, Payee = "John" }, "Please enter a valid cheque date");
            yield return new TestCaseData(new ChequeRequest() { ChequeDate = DateTime.MaxValue, Amount = 100.00, Payee = "John" }, "Please enter a valid cheque date");
            yield return new TestCaseData(new ChequeRequest() { ChequeDate = DateTime.Today, Amount = 0, Payee = "John" }, "Please enter a valid cheque amount");
            yield return new TestCaseData(new ChequeRequest() { ChequeDate = DateTime.Today, Amount = -1, Payee = "John" }, "Please enter a valid cheque amount");
            yield return new TestCaseData(new ChequeRequest() { ChequeDate = DateTime.Today, Amount = 10000000000000.00, Payee = "John" }, "Please enter a valid cheque amount");
            yield return new TestCaseData(new ChequeRequest() { ChequeDate = DateTime.Today, Amount = 100.00, Payee = "J" }, "Please enter a valid payee");
        }

        [Test, TestCaseSource(nameof(AmountWordTestData))]
        public void GetAmountWord_ExpectedResult(Double input, string expectResult)
        {
            var chequeService = new ChequeService();
            var result = chequeService.GetAmountWord(input);

            Assert.IsTrue(result == expectResult, $"incorrect amount word, expect {expectResult} but {result}");
        }

        [Test, TestCaseSource(nameof(ValidChequeTestData))]
        public void IsValidCheque_ExpectedResult(ChequeRequest input, string expectResult)
        {
            var chequeService = new ChequeService();
            var message = "";
            var result = chequeService.IsValidCheque(input, out message);

            Assert.IsTrue(message.Contains(expectResult), $"incorrect validation result, expect {expectResult} but {message}");
        }
    }
}
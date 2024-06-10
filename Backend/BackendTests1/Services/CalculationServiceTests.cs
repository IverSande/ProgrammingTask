using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Services.Tests
{
    [TestClass()]
    public class CalculationServiceTests
    {
        [TestMethod()]
        public void calculateSerialLoanByYearsTest()
        {
            //Tests a loan with no interest
            CalculationService calculationService = new CalculationService();
            List<long> longs = new List<long> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            long payment = 100;
            long loanAmount = 1200;
            int paymentYears = 1;
            Double loanInterest = 0;
            LoanPaymentTable loanPaymentTable = new LoanPaymentTable(payment, longs);

            Assert.AreEqual(calculationService.calculateSerialLoanByYears(loanAmount, loanInterest, paymentYears).ToString(), loanPaymentTable.ToString());
            
            //Test with interest of 10%
             longs = new List<long> { 10, 9, 8, 8, 7, 6, 5, 4, 3, 2, 2, 1 };
            payment = 100;
            loanAmount = 1200;
            paymentYears = 1;
            loanInterest = 0.1;
            loanPaymentTable = new LoanPaymentTable(payment, longs);

            Assert.AreEqual(calculationService.calculateSerialLoanByYears(loanAmount, loanInterest, paymentYears).ToString(), loanPaymentTable.ToString());
        }
    }
}
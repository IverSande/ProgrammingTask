using Backend.Models;
using System.Numerics;

namespace Backend.Services
{
    public interface ICalculationService
    {
        public LoanPaymentTable calculateSerialLoanByYears(long amount, double interest, int years);

    }
    public class CalculationService : ICalculationService
    {


        public LoanPaymentTable calculateSerialLoanByYears(long amount, double interest, int years)
        {
            //Describes the amount of interest each month
            List<long> monthlyInterest = new();

            int downPaymentMonths = years * 12;
            long paymentForEachMonth = amount / downPaymentMonths;
            long amountLeft = amount;

            for (int i = 0; i < downPaymentMonths; i++)
            {
                //Rounding to closest int, dont know what is standard practice, but never seen floats on loan calculators
                monthlyInterest.Add(Convert.ToInt64(amountLeft * (interest / 12)));
                amountLeft -= paymentForEachMonth;
            }

            return new LoanPaymentTable(paymentForEachMonth, monthlyInterest);
        }

    }
}

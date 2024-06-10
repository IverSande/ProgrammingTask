using Backend.Models;

namespace Backend.Interface
{
    public interface ICalculationService
    {
        public LoanPaymentTable calculateSerialLoanByYears(long amount, double interest, int years);

    }
}

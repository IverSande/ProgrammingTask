
using Newtonsoft.Json;
using System.Text.Json;

namespace Backend.Models
{
    public class LoanPaymentTable
    {
        long monthlyPay;
        List<long> payments;


        public LoanPaymentTable(long monthlyPay, List<long> payments)
        {
            this.monthlyPay = monthlyPay;
            this.payments = payments;
        }

        public List<long> Payments { get => payments; set => payments = value; }
        public long MonthlyPay { get => monthlyPay; set => monthlyPay = value; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}


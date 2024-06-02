using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {

        AritmaContext _context = new();

       // [DisableCors]
        [HttpGet]
        public ActionResult LoanCalculation(long amount, string loanType, int years)
        {

            CalculationService calculationService = new CalculationService();

            return _context.TypeLoans.Find(loanType) switch
            {
                TypeLoan t when t.LoanType == "Serie" 
                    => Ok(calculationService.calculateSerialLoanByYears(amount, t.Interest, years).ToString()),
                _  
                    => new BadRequestResult(),

                //Easly add more cases like this
                //TypeLoan t when t.LoanType == "Annuitet" 
                //    => Ok(calculationService.calculateAnnuitetLoanByYears(amount, t.Interest, years).ToString()),

            };

        }

    }
}

using Backend.Interface;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {

        private readonly AritmaContext _context;
        private readonly ICalculationService _calculationService;

        public LoanController(ICalculationService calculationService, AritmaContext context) {

            _calculationService = calculationService;
            _context = context;
        
        }


        [HttpGet]
        public ActionResult LoanCalculation(long amount, string loanType, int years)
        {


            return _context.TypeLoans.Find(loanType) switch
            {
                TypeLoan t when t.LoanType == "Serie" 
                    => Ok(_calculationService.calculateSerialLoanByYears(amount, t.Interest, years).ToString()),
                //Could return more description on what was wrong
                _   => new BadRequestResult(),

                //Easly add more cases like this
                //TypeLoan t when t.LoanType == "Annuitet" 
                //    => Ok(calculationService.calculateAnnuitetLoanByYears(amount, t.Interest, years).ToString()),

            };

        }

        [HttpGet]
        [Route("getAllTypes")]
        public ActionResult getAllLoanTypes()
        {
            return Ok(_context.TypeLoans.Select(a => new {a.LoanType, a.Interest}));
        
        }

    }
}

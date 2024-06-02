using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Loan
{
    public int Id { get; set; }

    public long Amount { get; set; }

    public string LoanType { get; set; } = null!;

    public virtual TypeLoan LoanTypeNavigation { get; set; } = null!;
}

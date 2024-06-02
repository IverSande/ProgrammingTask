using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class TypeLoan
{
    public string LoanType { get; set; } = null!;

    public double Interest { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}

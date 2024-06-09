import { Component } from '@angular/core';
import { NgForm, FormsModule } from '@angular/forms';
import { LoanPayment, LoanService } from '../services/loan-service/loan.service';
import { LoanPaymentTableComponent } from '../loan-payment-table/loan-payment-table.component';

@Component({
  selector: 'app-calculator-page',
  standalone: true,
  imports: [FormsModule, LoanPaymentTableComponent],
  templateUrl: './calculator-page.component.html',
  styleUrl: './calculator-page.component.scss'
})
export class CalculatorPageComponent {
  years = 25;
  calculatedLoan : LoanPayment = {Payments : [], MonthlyPay : 0};

  constructor(private loanService : LoanService){}



  valueChanged(e: any) {
    this.years = e.target.value;
  }

  onSubmit(calculatorForm: NgForm){
    this.loanService.getCalculatedLoan(calculatorForm.value.amount , "Serie", this.years).subscribe(val => {this.calculatedLoan = val});
  }
}

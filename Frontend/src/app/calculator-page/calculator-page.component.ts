import { Component } from '@angular/core';
import { NgForm, FormsModule } from '@angular/forms';
import { LoanPayment, LoanService } from '../services/loan-service/loan.service';

@Component({
  selector: 'app-calculator-page',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './calculator-page.component.html',
  styleUrl: './calculator-page.component.scss'
})
export class CalculatorPageComponent {
  years = 25;
  monthlyPay : any;

  constructor(private loanService : LoanService){}



  valueChanged(e: any) {
    this.years = e.target.value;
  }

  onSubmit(calculatorForm: NgForm){
    this.monthlyPay = this.loanService.calculateLoan(calculatorForm.value.amount , "Serie", this.years);
  }
}

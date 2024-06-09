import { Component, Input } from '@angular/core';
import { LoanPayment } from '../services/loan-service/loan.service';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-loan-payment-table',
  standalone: true,
  imports: [NgFor],
  templateUrl: './loan-payment-table.component.html',
  styleUrl: './loan-payment-table.component.scss'
})
export class LoanPaymentTableComponent {

  @Input()
  calculatedLoan : LoanPayment = {Payments : [], MonthlyPay : 0};

}

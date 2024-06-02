import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment.development';

export interface LoanPayment{
  MonthlyPay : number,
  Payments : number[]
}

@Injectable({
  providedIn: 'root'
})
export class LoanService {

  constructor(private http: HttpClient) { }



  calculateLoan(amount: number, loanType: string, years: number){

    //Need to research environment a bit more
    this.http.get<LoanPayment>(environment.apiUrl + `/api/Loan?amount=${amount}&loanType=${loanType}&years=${years}`).subscribe(loanData => {

      return loanData;

    });
  }



}

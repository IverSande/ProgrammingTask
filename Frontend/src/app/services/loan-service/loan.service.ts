import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment.development';
import { Observable } from 'rxjs';

export interface LoanPayment{
  MonthlyPay : number,
  Payments : number[]
}
export interface LoanType{
  loanType: String,
  interest : number
}

@Injectable({
  providedIn: 'root'
})
export class LoanService {

  constructor(private http: HttpClient) { }



  getCalculatedLoan(amount: number, loanType: string, years: number): Observable<LoanPayment>{
    //Need to research environment a bit more
    return this.http.get<LoanPayment>(environment.apiUrl + `/api/Loan?amount=${amount}&loanType=${loanType}&years=${years}`);
  }

  getLoanTypes() : Observable<LoanType[]>{
    return this.http.get<LoanType[]>(environment.apiUrl + `/api/Loan/getAllTypes`);
  }



}

import { Component } from '@angular/core';
import { LoanService, LoanType } from '../services/loan-service/loan.service';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-loan-page',
  standalone: true,
  imports: [NgFor],
  templateUrl: './loan-page.component.html',
  styleUrl: './loan-page.component.scss'
})
export class LoanPageComponent {
  loanTypes : LoanType[] = [];

  constructor(private loanService : LoanService){}


  ngOnInit(){
    this.loanService.getLoanTypes().subscribe(val => {this.loanTypes = val});
  }
}

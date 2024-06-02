import { Routes } from '@angular/router';
import { CalculatorPageComponent } from './calculator-page/calculator-page.component';
import { LoanPageComponent } from './loan-page/loan-page.component';

export const routes: Routes = [
    {path: 'calculator-page', component: CalculatorPageComponent},
    {path: 'loan-page', component: LoanPageComponent},
];

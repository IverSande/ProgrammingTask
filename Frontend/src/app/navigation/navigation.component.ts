import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { LoanPageComponent } from '../loan-page/loan-page.component';
import { CalculatorPageComponent } from '../calculator-page/calculator-page.component';

@Component({
  selector: 'app-navigation',
  standalone: true,
  imports: [CommonModule, RouterOutlet, NavigationComponent, CalculatorPageComponent, LoanPageComponent, RouterLink, RouterLinkActive],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.scss'
})
export class NavigationComponent {

}

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { NavigationComponent } from './navigation/navigation.component';
import { CalculatorPageComponent } from './calculator-page/calculator-page.component';
import { LoanPageComponent } from './loan-page/loan-page.component';



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, 
            RouterOutlet, 
            NavigationComponent, 
            CalculatorPageComponent, 
            LoanPageComponent, 
            RouterLink, 
            RouterLinkActive
          ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Frontend';
}

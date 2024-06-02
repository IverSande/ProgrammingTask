import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoanPaymentTableComponent } from './loan-payment-table.component';

describe('LoanPaymentTableComponent', () => {
  let component: LoanPaymentTableComponent;
  let fixture: ComponentFixture<LoanPaymentTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoanPaymentTableComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LoanPaymentTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

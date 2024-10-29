import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CdbCalculatorComponent } from './cdb-calculator.component';

describe('CdbCalculatorComponent', () => {
  let component: CdbCalculatorComponent;
  let fixture: ComponentFixture<CdbCalculatorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CdbCalculatorComponent]
    });
    fixture = TestBed.createComponent(CdbCalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

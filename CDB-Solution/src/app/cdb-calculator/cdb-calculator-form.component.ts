import { Component } from '@angular/core';
import { InvestmentService } from './cdb-calculator.service';
import { InvestmentRequest } from './cdb-calculator.request';
import { InvestmentResult } from './cdb-calculator.result';



@Component({
    selector: 'app-cdb-calculator-form',
    templateUrl: './cdb-calculator.component.html',
    styleUrls: ['./cdb-calculator.component.scss']
})

export class CdbCalculatorFormComponent {
    request: InvestmentRequest = { valorInicial: 0, prazoMeses: 1 };
    result?: InvestmentResult;
    valorInicial: number = 0;  
    prazoMeses: number = 0;    
    resultadoBruto: number | null = null; 
    resultadoLiquido: number | null = null;

    constructor(private investmentService: InvestmentService) { }

    calcular(): void {
        this.investmentService.calcular(this.request).subscribe(
            res => this.result = res,
            err => alert('Erro no cálculo: ' + err.message)
        );
    }

    clearForm() {
        this.valorInicial = 0;
        this.prazoMeses = 0;
        this.resultadoBruto = null;
        this.resultadoLiquido = null;
      }
}
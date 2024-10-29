import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { InvestmentRequest } from './cdb-calculator.request';
import { InvestmentResult } from './cdb-calculator.result';

@Injectable({
  providedIn: 'root'
})
export class InvestmentService {
  private apiUrl = 'https://localhost:7151/api/investment';

  //https://localhost:7151/api/investment/calcular

  constructor(private http: HttpClient) { }

  calcular(request: InvestmentRequest): Observable<InvestmentResult> {
    return this.http.post<InvestmentResult>(`${this.apiUrl}/calcular`, request);
  }
}
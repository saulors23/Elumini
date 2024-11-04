import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CdbCalculatorFormComponent } from './cdb-calculator/cdb-calculator-form.component';

const routes: Routes = [
  { path: '', redirectTo: '/cdb-calculator', pathMatch: 'full' }, 
  { path: 'cdb-calculator', component: CdbCalculatorFormComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

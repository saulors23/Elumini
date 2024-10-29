import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CdbCalculatorFormComponent } from './cdb-calculator/cdb-calculator-form.component';

@NgModule({
  declarations: [   
    AppComponent, 
    CdbCalculatorFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,    
  ],

  exports: [
    CdbCalculatorFormComponent
  ],

  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

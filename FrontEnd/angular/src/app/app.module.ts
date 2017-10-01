import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CompanyModule } from './modules/companies/company.module';

@NgModule(
{
  declarations: [AppComponent],
  imports: [ BrowserModule, CompanyModule ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
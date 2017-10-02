import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { CompanyModule } from './modules/companies/company.module';
import { CompanyService } from './core/services/company.service';

@NgModule(
{
  declarations: [AppComponent],
  imports: [ BrowserModule, CompanyModule, HttpClientModule ],
  providers: [CompanyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
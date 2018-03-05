import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from './app-routing.module';
import { CompanyModule } from './core/companies/companies.module';
import { OrderModule } from './core/orders/orders.module';

import { AppComponent } from './app.component';

@NgModule(
{
  imports:
  [
    BrowserModule,
    HttpClientModule,
    OrderModule,
    CompanyModule,
    AppRoutingModule,
  ],
  declarations: [ AppComponent ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";
import { Router } from '@angular/router';

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
    OrderModule,        // Module import order matters!!! The routes are no longer
    CompanyModule,      // in one file, they are distributed across many modules...
    AppRoutingModule
  ],
  declarations: [ AppComponent ],
  bootstrap:    [ AppComponent ]
})
export class AppModule
{
  constructor(router: Router)
  {
    // Just to display/inspect final router configuration (can be deleted)
    // console.log('Routes: ', JSON.stringify(router.config, undefined, 2));
  }
}
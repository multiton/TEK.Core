import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { HttpClientModule } from "@angular/common/http"
import { Router } from '@angular/router'

import { CompaniesModule } from './core/companies/companies.module'
import { OrdersModule } from './core/orders/orders.module'
import { ConfigValuesModule } from './core/config-values/config-values.module';
import { AppRoutingModule } from './app-routing.module'

import { AppComponent } from './app.component'

@NgModule(
{
  imports:
  [
    BrowserModule,
    HttpClientModule,
    OrdersModule,       // Module import order matters!!! The routes are no longer
    CompaniesModule,    // in one file, they are distributed across many modules...    
    ConfigValuesModule,
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
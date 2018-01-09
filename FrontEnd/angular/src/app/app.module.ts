import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { CompanyModule } from './core/companies/companies.module';
import { CompanyListComponent } from './core/companies/company-list/company-list.component';

const appRoutes: Routes =
[
  { path: 'company-list', component: CompanyListComponent }
];

@NgModule(
{
  declarations: [ AppComponent ],
  imports:
  [
    BrowserModule,
    CompanyModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
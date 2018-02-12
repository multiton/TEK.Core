import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CompanyComponent } from "./company/company.component";
import { CompanyListComponent } from "./company-list/company-list.component";

const companyRoutes: Routes =
[
  { path: 'companies',  component: CompanyListComponent },
  { path: 'company/:id', component: CompanyComponent }
];

@NgModule({
  imports: [ RouterModule.forChild(companyRoutes) ],
  exports: [ RouterModule ]
})
export class CompanyRoutingModule { }
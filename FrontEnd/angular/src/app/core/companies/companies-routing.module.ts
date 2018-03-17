import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CompanyComponent } from "./company/company.component";
import { CompanyListComponent } from "./company-list/company-list.component";
import { CompanyResolver } from "./company/company-resolver.service";

const companyRoutes: Routes =
[
  { path: 'companies',  component: CompanyListComponent },
  { path: 'company/:id', component: CompanyComponent, resolve: { company : CompanyResolver } }
];

@NgModule({
  imports:   [ RouterModule.forChild(companyRoutes) ],
  providers: [ CompanyResolver ]
})
export class CompanyRoutingModule
{
  // Give each feature module its own route configuration file.
  // Routes have a tendency to grow...
}
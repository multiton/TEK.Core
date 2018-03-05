import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { CompanyService } from './shared/company.srevice';
import { CompanyComponent } from './company/company.component';
import { CompanyListComponent } from './company-list/company-list.component';
import { CompanyRoutingModule } from './companies-routing.module';

@NgModule(
{
  declarations: [ CompanyComponent, CompanyListComponent],
  imports:      [ CommonModule, RouterModule, CompanyRoutingModule ],
  providers:    [ CompanyService ]
})
export class CompanyModule { }
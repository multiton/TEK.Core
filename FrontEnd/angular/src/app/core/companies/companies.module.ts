import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { CompanyListComponent } from './company-list/company-list.component';
import { CompanyComponent } from './company/company.component';

import { CompanyService } from './shared/company.srevice';

@NgModule(
{
  declarations: [ CompanyComponent, CompanyListComponent],
  imports:      [ CommonModule, RouterModule ],
  exports:      [ CompanyComponent, CompanyListComponent],
  providers:    [ CompanyService ]
})
export class CompanyModule { }
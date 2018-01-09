import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompanyListComponent } from './company-list/company-list.component';
import { CompanyService } from './shared/company.srevice';

@NgModule(
{
  declarations: [CompanyListComponent],
  imports: [CommonModule],
  exports: [CompanyListComponent],
  providers: [ CompanyService ],
})
export class CompanyModule { }
import { Component } from '@angular/core';
import { CompanyService } from './core/services/company.service';
import { Company } from './core/models/company';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent
{
  private companies : Company[];

  constructor(private companyService : CompanyService) { }

  LoadAllCompanies() : void
  {
    this.companyService.getAll().subscribe(data => this.companies = data);
  }

  ClearCompanies() : void
  {
    this.companies = [];
  }
}
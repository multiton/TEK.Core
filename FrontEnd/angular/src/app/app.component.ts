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
  private companies : Array<Company> = [];

  constructor(private companyService : CompanyService)
  {
    companyService.getAll().subscribe(data => this.companies = data);
  }
}
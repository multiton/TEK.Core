import { Component } from '@angular/core';
import { CompanyService } from './core/services/company.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent
{
  title = 'Hello world !!!';

  companies;

  constructor(private companyService : CompanyService)   
  {
    let cmp = companyService.getAll();
    let c = cmp.subscribe(data => this.companies);
    let p = this.companies;
  }
}
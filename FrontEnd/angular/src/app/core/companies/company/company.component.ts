import { Component, OnInit, OnDestroy } from '@angular/core';
import { ISubscription } from 'rxjs/Subscription';

import { Company } from '../shared/company.model';
import { CompanyService } from '../shared/company.srevice';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent implements OnInit, OnDestroy
{
  private company : Company;
  private subscription: ISubscription;

  constructor(private companyService : CompanyService) { }

  ngOnInit(): void
  {
    // this.subscription = this.companyService.get(123)
    //   .subscribe(data => this.company = data);
  }

  ngOnDestroy()
  {
    if (!!this.subscription)
    {
      this.subscription.unsubscribe();
    }
  }
}
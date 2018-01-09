import { Component } from '@angular/core';
import { ISubscription } from 'rxjs/Subscription';

import { Company } from '../shared/company.model';
import { CompanyService } from '../shared/company.srevice';
import { OnInit, OnDestroy } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.css']
})
export class CompanyListComponent implements OnInit, OnDestroy
{
  private companies : Company[];
  private subscription: ISubscription;

  constructor(private companyService : CompanyService) { }

  ngOnInit(): void
  {
    this.subscription = this.companyService
      .getAll()
      .subscribe(data => this.companies = data);
  }

  ngOnDestroy()
  {
    if (!!this.subscription)
    {
      this.subscription.unsubscribe();
    }
  }
}
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ISubscription } from 'rxjs/Subscription';
import { ActivatedRoute } from "@angular/router";

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

  constructor(private route: ActivatedRoute, private companyService : CompanyService) { }

  ngOnInit(): void
  {     
    this.subscription =
       this.companyService
       .get(this.route.snapshot.params.id)
       .subscribe(data => this.company = data);
  }

  ngOnDestroy()
  {
    if (!!this.subscription) this.subscription.unsubscribe();
  }
}
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
  private company : Company; //= {id: 0, name: ""};
  private subscription: ISubscription;

  constructor(private route: ActivatedRoute, private companyService : CompanyService) { }

  ngOnInit(): void
  {   
    //console.log("ID=" + this.route.snapshot.params.id);
    
    //console.log(this.route.data.subscribe(....));

    this.route.data.subscribe(
      (data: {company: Company}) =>
      {
        this.company = data.company;

        this.companyService
          .get(this.route.snapshot.params.id)
          .subscribe(data => this.company = data);       
        
        // this.userService.currentUser.subscribe(
        //   (userData: User) =>
        //   {
        //     this.currentUser = userData;
        //     this.isUser = (this.currentUser.username === this.profile.username);
        //   }
        // );
      }
    );

    // this.subscription = this.companyService
    //   .get(this.route.snapshot.params.id)
    //   .subscribe(data => this.company = data);
  }

  ngOnDestroy()
  {
    if (!!this.subscription) this.subscription.unsubscribe();
  }
}
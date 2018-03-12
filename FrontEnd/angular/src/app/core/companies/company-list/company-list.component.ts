import { ActivatedRoute, ParamMap } from '@angular/router'
import { Component, OnInit } from '@angular/core'

import { Company } from '../shared/company.model'
import { CompanyService } from '../shared/company.srevice'

import { Observable } from 'rxjs/Observable'
import 'rxjs/add/operator/switchMap';

@Component({templateUrl: './company-list.component.html'})
export class CompanyListComponent implements OnInit
{
  private companies : Observable<Company[]>
  private selectedId : number

  constructor(
    private companyService : CompanyService,
    private route: ActivatedRoute ) { }

  ngOnInit(): void
  {   
    this.companies = this.route.paramMap.switchMap((params: ParamMap) =>
    {
        this.selectedId = +params.get('id');
        return this.companyService.getAll();
    });      
  }
}
import { Component, OnInit } from '@angular/core'
import { AsyncPipe } from '@angular/common'
import { ActivatedRoute } from "@angular/router"
import { Observable } from 'rxjs/Observable';

import { Company } from '../shared/company.model'
import { CompanyService } from '../shared/company.srevice'

@Component({
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent implements OnInit
{
  private company : Observable<Company>

  constructor(private companyService : CompanyService, private route: ActivatedRoute) { }

  ngOnInit(): void
  {
       this.company = this.companyService.get(this.route.snapshot.params.id)
  }
}
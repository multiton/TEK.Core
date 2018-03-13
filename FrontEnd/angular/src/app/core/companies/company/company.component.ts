import { Component, OnInit } from '@angular/core'
import { ActivatedRoute, Router } from "@angular/router"
import { Observable } from 'rxjs/Observable';

import { Company } from '../shared/company.model'
import { CompanyService } from '../shared/company.srevice'

@Component({templateUrl: './company.component.html'})
export class CompanyComponent implements OnInit
{
  private company : Observable<Company>

  constructor(
    private companyService : CompanyService,
    private route: ActivatedRoute,
    private router: Router)  { }

  ngOnInit(): void
  {
    this.company = this.companyService.getSingle(this.route.snapshot.params.id);
  }

  save(newCompany: Company)
  {
    let companyId = newCompany ? newCompany.id : null; 
    this.router.navigate(['/companies', { id: companyId }]);
  }

  delete(existingCompany: Company)
  {
    if (existingCompany)
    {
      this.companyService.delete(existingCompany.id).subscribe();
      this.router.navigate(['/companies']);
    }
  }
}
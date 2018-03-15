import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Router, Resolve, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/take';

import { Company } from "../shared/company.model";
import { CompanyService } from "../shared/company.srevice";

@Injectable()
export class CompanyResolver implements Resolve<Company>
{
  constructor(private companyService: CompanyService, private router: Router) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Company>
  {
    let id = +route.paramMap.get('id');

    return this.companyService.getSingle(id).take(1).map(company =>
    {
      if (company) return company;

      // id not found
      this.router.navigate(['/companies']);
      return null;      
    });
  }
}
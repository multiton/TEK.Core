import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

import { Company } from './company.model';
import { RestServiceBase } from '../../../rest-service-base';

@Injectable()
export class CompanyService extends RestServiceBase<Company>
{
  constructor(http: HttpClient)
   {
     super(http, "Company");
   }
}
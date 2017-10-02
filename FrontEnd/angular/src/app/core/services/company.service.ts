import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

import { Subject } from "rxjs/Subject";
import { Observable } from 'rxjs/Observable';

import { Company } from '../models/company';

@Injectable()
export class CompanyService
{
  constructor(private http: HttpClient /*, private urlHelper: UrlHelper */) {}
  
  getAll() : Observable<Company[]>
  {
    return this.http.get<Company[]>('http://localhost:51404/api/company');
  }
}
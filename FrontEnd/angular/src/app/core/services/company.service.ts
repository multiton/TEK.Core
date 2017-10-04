import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { HttpErrorResponse } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { Company } from '../models/company';

@Injectable()
export class CompanyService
{
  constructor(private http: HttpClient) { }
  
  getAll() : Observable<Company[]>
  {
    return this.http
    .get<Company[]>('http://localhost:51404/api/company')
    .catch(this.handleError);
  }

  private handleError(err: HttpErrorResponse)
  {
    console.log(err.message);
    return Observable.throw(err);
  }
}
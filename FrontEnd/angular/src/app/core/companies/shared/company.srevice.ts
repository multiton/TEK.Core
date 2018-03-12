import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { HttpErrorResponse } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { Company } from './company.model';
import { environment } from '../../../../environments/environment';

@Injectable()
export class CompanyService
{
  constructor(private http: HttpClient) { }
  
  public getAll() : Observable<Company[]>
  {
    return this.http
      .get<Company[]>(environment.apiEndpoint + 'Company')
      .catch(this.handleError);
  }

  public get(id: number) : Observable<Company>
  {
    return this.http
      .get<Company>(environment.apiEndpoint + 'Company/' + id)
      .catch(this.handleError);
  }

  private handleError(err: HttpErrorResponse)
  {
    console.log(err.message);
    return Observable.throw(err);
  }
}
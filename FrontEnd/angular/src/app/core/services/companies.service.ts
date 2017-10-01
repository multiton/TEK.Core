import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core';

@Injectable()
export class CompaniesService
{
  constructor(private http: HttpClient /*, private urlHelper: UrlHelper */) {}
  
  getAll()
  {
    return this.http.get('api/');
  }
}
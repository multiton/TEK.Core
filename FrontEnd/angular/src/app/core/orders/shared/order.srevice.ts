import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { HttpErrorResponse } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { Order } from './order.model';

@Injectable()
export class OrderService
{
  constructor(private http: HttpClient) { }
  
  public getAll() : Observable<Order[]>
  {
    return this.http
      .get<Order[]>('http://localhost:51404/api/Order')
      .catch(this.handleError);
  }

  public get(id: number) : Observable<Order>
  {
    return this.http
      .get<Order>('http://localhost:51404/api/Order/'+id)
      .catch(this.handleError);
  }

  private handleError(err: HttpErrorResponse)
  {
    console.log(err.message);
    return Observable.throw(err);
  }
}
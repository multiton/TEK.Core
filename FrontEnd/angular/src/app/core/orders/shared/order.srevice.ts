import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

import { Order } from './order.model';
import { RestServiceBase } from '../../../rest-service-base';

@Injectable()
export class OrderService extends RestServiceBase<Order>
{
  constructor(http: HttpClient)
  {
    super(http, "Order");
  }
}
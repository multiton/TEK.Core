import { Component, OnInit } from '@angular/core'
import { Observable } from 'rxjs/Observable'

import { Order } from '../shared/order.model'
import { OrderService } from '../shared/order.srevice'

@Component({ templateUrl: './order-list.component.html' })
export class OrderListComponent implements OnInit
{
  private orders : Observable<Order[]>

  constructor(private orderService : OrderService) { }

  ngOnInit(): void
  {
    this.orders = this.orderService.getAll()
  }
}
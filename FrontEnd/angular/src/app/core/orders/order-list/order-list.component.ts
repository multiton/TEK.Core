import { Component, OnInit } from '@angular/core'
import { AsyncPipe } from '@angular/common'

import { Order } from '../shared/order.model'
import { OrderService } from '../shared/order.srevice'
import { Observable } from 'rxjs/Observable'

@Component({
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit
{
  private orders : Observable<Order[]>

  constructor(private orderService : OrderService) { }

  ngOnInit(): void
  {
    this.orders = this.orderService.getAll()
  }
}
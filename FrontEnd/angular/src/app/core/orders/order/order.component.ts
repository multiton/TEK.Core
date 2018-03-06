import { Component, OnInit } from '@angular/core'
import { AsyncPipe } from '@angular/common'
import { ActivatedRoute } from "@angular/router"
import { Observable } from 'rxjs/Observable';

import { Order } from '../shared/order.model'
import { OrderService } from '../shared/order.srevice'

@Component({ templateUrl: './order.component.html' })
export class OrderComponent implements OnInit
{
  private order : Observable<Order>

  constructor(private orderService : OrderService, private route: ActivatedRoute) { }

  ngOnInit(): void
  {
       this.order = this.orderService.get(this.route.snapshot.params.id)
  }
}
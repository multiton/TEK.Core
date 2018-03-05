import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { OrderService } from './shared/order.srevice';
import { OrderComponent } from "./order/order.component";
import { OrderListComponent } from './order-list/order-list.component';
import { OrderRoutingModule } from "./orders-routing.module";

@NgModule(
{
  declarations: [ OrderListComponent, OrderComponent],
  imports:      [ CommonModule, RouterModule, OrderRoutingModule ],
  providers:    [ OrderService ]
})
export class OrderModule { }
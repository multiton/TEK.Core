import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { OrderComponent } from "./order/order.component";
import { OrderListComponent } from "./order-list/order-list.component";

const orderRoutes: Routes =
[
  { path: 'orders',  component: OrderListComponent },
  { path: 'order/:id', component: OrderComponent }
];

@NgModule({ imports: [ RouterModule.forChild(orderRoutes) ] })
export class OrderRoutingModule { }
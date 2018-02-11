import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { OrderListComponent } from './order-list/order-list.component';
import { OrderService } from './shared/order.srevice';

@NgModule(
{
  declarations: [ OrderListComponent],
  imports:      [ CommonModule, RouterModule ],
  exports:      [ OrderListComponent],
  providers:    [ OrderService ]
})
export class OrderModule { }
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { OrderService } from './shared/order.srevice';
import { OrderListComponent } from './order-list/order-list.component';

@NgModule(
{
  declarations: [ OrderListComponent],
  imports:      [ CommonModule, RouterModule ],
  providers:    [ OrderService ]
})
export class OrderModule { }
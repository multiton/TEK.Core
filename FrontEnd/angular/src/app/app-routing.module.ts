import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { OrderListComponent } from './core/orders/order-list/order-list.component';

const appRoutes: Routes = [ { path: 'orders', component: OrderListComponent } ];

@NgModule({
  imports: [ RouterModule.forRoot(appRoutes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
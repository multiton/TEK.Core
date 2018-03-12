import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { ConfigValueService } from './shared/config-value.service';
// import { ConfigComponent } from "./order/config.component";
// import { ConfigListComponent } from './config-list/config-list.component';
// import { ConfigRoutingModule } from "./configs-routing.module";

@NgModule(
{
//  declarations: [ ConfigListComponent, ConfigComponent],
//  imports:      [ CommonModule, RouterModule, ConfigRoutingModule ],
  providers:    [ ConfigValueService ]
})
export class ConfigValuesModule { }
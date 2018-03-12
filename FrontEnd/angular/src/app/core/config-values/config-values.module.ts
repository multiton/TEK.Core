import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { ConfigValueService } from './shared/config-value.service';
import { ConfigValueRoutingModule } from './config-values-routing.module';
import { ConfigValueListComponent } from './config-value-list/config-value-list.component';
import { ConfigValueComponent } from './config-value/config-value.component';

@NgModule(
{
  declarations: [ ConfigValueListComponent, ConfigValueComponent],
  imports:      [ CommonModule, RouterModule, ConfigValueRoutingModule ],
  providers:    [ ConfigValueService ]
})
export class ConfigValuesModule { }
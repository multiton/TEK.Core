import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ConfigValueComponent } from "./config-value/config-value.component";
import { ConfigValueListComponent } from "./config-value-list/config-value-list.component";

const configValueRoutes: Routes =
[
  { path: 'configValues',  component: ConfigValueListComponent },
  { path: 'configValue/:id', component: ConfigValueComponent }
];

@NgModule({ imports: [ RouterModule.forChild(configValueRoutes) ] })
export class ConfigValueRoutingModule { }
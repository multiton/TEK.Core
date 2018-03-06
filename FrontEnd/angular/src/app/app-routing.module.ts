import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const appRoutes: Routes = [ { path: '',  redirectTo: '/companies',  pathMatch: 'full'} ];

@NgModule({
  imports: [ RouterModule.forRoot(appRoutes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule
{
  // 1. Separates routing concerns from other application concerns
  // 2. Provides a module to replace or remove when testing
  // 3. Provides a location for routing service providers, guards and resolvers
  // 4. Does not declare components

  // Only call "RouterModule.forRoot" in the root AppRoutingModule. In any other (feature)
  // module, you must call the "RouterModule.forChild" method to register additional routes.
}
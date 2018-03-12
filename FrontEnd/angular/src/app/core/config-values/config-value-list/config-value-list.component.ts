import { Component, OnInit } from '@angular/core'
import { Observable } from 'rxjs/Observable'

import { ConfigValue } from '../shared/config-value.model';
import { ConfigValueService } from '../shared/config-value.service';

@Component({ templateUrl: './config-value-list.component.html' })
export class ConfigValueListComponent implements OnInit
{
  private configValues : Observable<ConfigValue[]>

  constructor(private configValueService : ConfigValueService) { }

  ngOnInit(): void
  {
    this.configValues = this.configValueService.getAll()
  }
}
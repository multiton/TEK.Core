import { Component, OnInit } from '@angular/core'
import { ActivatedRoute } from "@angular/router"
import { Observable } from 'rxjs/Observable';

import { ConfigValue } from '../shared/config-value.model';
import { ConfigValueService } from '../shared/config-value.service';

@Component({ templateUrl: './config-value.component.html' })
export class ConfigValueComponent implements OnInit
{
  private configValue : Observable<ConfigValue>

  constructor(private configValueService : ConfigValueService, private route: ActivatedRoute) { }

  ngOnInit(): void
  {
    this.configValue = this.configValueService.getSingle(this.route.snapshot.params.id)
  }
}
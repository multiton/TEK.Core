import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

import { ConfigValue } from './config-value.model';
import { RestServiceBase } from '../../../rest-service-base';

@Injectable()
export class ConfigValueService extends RestServiceBase<ConfigValue>
{
  constructor(http: HttpClient)
  {
    super(http, "ConfigValue");
  }
}
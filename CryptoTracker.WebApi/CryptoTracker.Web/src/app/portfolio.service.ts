import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';

import { PortfolioModel } from './models/PortfolioModel';
import { PortfolioItemModel } from './models/PortfolioItemModel';
import { PORTFOLIOS } from './mock-data/mock-portfolio';

@Injectable()
export class PortfolioService {

  constructor() { }

  getPortfolios(): Observable<PortfolioModel[]> {
    return of(PORTFOLIOS);
  }
}

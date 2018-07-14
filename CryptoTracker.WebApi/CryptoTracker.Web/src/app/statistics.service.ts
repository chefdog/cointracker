import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { MessageService } from './message.service';
import { StatModel } from './models/StatModel';
import { STATS } from './mock-data/mock-stats';

@Injectable()
export class StatisticsService {

  constructor(private messageService: MessageService) { }
 

  getStats(): Observable<StatModel[]> {
    this.messageService.add('HeroService: fetched heroes');
    return of(STATS);
  }
}

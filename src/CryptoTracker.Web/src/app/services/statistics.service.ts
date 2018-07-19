import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { MessageService } from './message.service';
import { StatModel } from '../models/StatModel';
import { STATS } from '../mock-data/mock-stats';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class StatisticsService {
  private webapi= 'http://localhost:52187/api/statistics';

  constructor(
    private messageService: MessageService,
    private http: HttpClient
  ) { }
 

  getStats(): Observable<StatModel[]> {
    return this.http
      .get<StatModel[]>(this.webapi)
      .pipe(
        tap(statistics => this.log('fetched stats')),
        catchError(this.handleError('getStats', []))
      );
    
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
   
      // TODO: send the error to remote logging infrastructure
      console.log(error); // log to console instead
   
      // TODO: better job of transforming error for user consumption
      this.log('${operation} failed: ${error.message}');
   
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
  
  private log(message: string) {
    this.messageService.add('StatisticsService: ${message}');
  }
}

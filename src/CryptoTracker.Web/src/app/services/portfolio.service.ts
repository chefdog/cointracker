import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { MessageService } from './message.service';

import { PortfolioModel } from '../models/PortfolioModel';
import { PortfolioItemModel } from '../models/PortfolioItemModel';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class PortfolioService {

  private webapi = 'http://localhost:52187/api/portfolio/';

  constructor(private messageService: MessageService,
    private http: HttpClient) { }

  
/** fetch portolio collection */
  getPortfolios(): Observable<PortfolioModel[]> {
    return this.http
      .get<PortfolioModel[]>(this.webapi)
      .pipe(
        tap(statistics => this.log('fetched portfolios')),
        catchError(this.handleError('getPortfolios', []))
      );    
  }
/** get portolio by id */
  getPortfolio(id: number): Observable<PortfolioModel> {    
    return this.http.get<PortfolioModel>(this.webapi + id).pipe(
      tap(_ => this.log('fetched portfolio id=${id}')),
      catchError(this.handleError<PortfolioModel>('getPortfolio id=${id}'))
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

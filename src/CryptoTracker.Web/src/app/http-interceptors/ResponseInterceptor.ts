import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

/** Pass untouched request through to the next request handler. */
@Injectable()
export class ResponseInterceptor implements HttpInterceptor {

  intercept(req: HttpRequest<any>, next: HttpHandler):
    Observable<HttpEvent<any>> {
      
      return next.handle(req).map((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse) {
          console.log(JSON.stringify(event.body.model));
          return event.body.model;
        }
        return event; 
      });
  }
}
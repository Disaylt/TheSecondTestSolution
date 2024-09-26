import { Injectable } from "@angular/core";
import { Observable, catchError, tap, throwError } from "rxjs";
import { Router } from "@angular/router";
import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";

@Injectable()
export class ErrorHttpInterceptor implements HttpInterceptor{

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            catchError((error: HttpErrorResponse) => {
                
                //в зависимости кода ошибки обработка действий...
                console.log("http error")

                return throwError(() => error.message);
            })
          );
    }
    
}
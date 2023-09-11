import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';


/**
 * Adds a default error handler to all requests.
 */
@Injectable({
    providedIn: 'root'
})
export class ErrorHandlerInterceptor implements HttpInterceptor {
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError((error: HttpErrorResponse) => this.errorHandler(error)));
    }

    private errorHandler(response: HttpErrorResponse): Observable<HttpEvent<any>> {
        if (response['status'] >= 400) {
            console.error(`An error occurred during your request: ${response.status} ${response.statusText}`);
        }

        if (response.error && response.error.error && response.error.error.message) {
            alert(response.error.error.message);
        }

        throw response;
    }
}

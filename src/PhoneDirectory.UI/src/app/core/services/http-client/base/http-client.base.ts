import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { RequestOptions } from '@core/services';

export abstract class HttpClientBase {
    protected abstract readonly apiUrl: string;

    protected constructor(private http: HttpClient) {}

    /**
     * GET request
     * and map to data property
     * @param {string} endPoint it doesn't need / in front of the end point
     * @param {RequestOptions} options options of the request like headers, body, etc.
     * @returns {Observable<T>} Observable return type
     */
    get<T>(endPoint: string, options?: RequestOptions): Observable<T> {
        return this.http //
            .get<T>(`${this.apiUrl}${endPoint}`, options);
    }

    /**
     * POST request
     * @param {string} endPoint end point of the api
     * @param {any | null} body body of the request.
     * @returns {Observable<T>} json object
     */
    post<T = null>(endPoint: string, body: any | null = null): Observable<T> {
        return this.http.post<T>(`${this.apiUrl}${endPoint}`, body);
    }

    /**
     * PUT request
     * @param {string} endPoint end point of the api
     * @param {any | null} body body of the request.
     * @returns {Observable<T>} json object
     */
    put<T = null>(endPoint: string, body: any | null): Observable<T> {
        return this.http
            .put<T>(`${this.apiUrl}${endPoint}`, body);
    }

    /**
     * DELETE request
     * @param {string} endPoint end point of the api
     * @param {RequestOptions} options options of the request like headers, body, etc.
     * @returns {Observable<T>} observable return type
     */
    delete<T = null>(endPoint: string, options?: RequestOptions): Observable<T> {
        return this.http.delete<T>(`${this.apiUrl}${endPoint}`, options);
    }
}

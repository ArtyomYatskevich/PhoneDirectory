import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { PhoneDirectoryHttpClient } from '@core/services';

import { Phone, UpdatePhone } from '../models';

@Injectable({
    providedIn: 'root'
})
export class PhoneDirectoryService {
    constructor(private httpClient: PhoneDirectoryHttpClient) {}

    getAll(): Observable<Phone[]> {
        return this.httpClient.get('phones');
    }

    addPhone(phone: UpdatePhone): Observable<Phone> {
        return this.httpClient.post('phones', phone);
    }

    updatePhone(phone: UpdatePhone, id: number): Observable<Phone> {
        return this.httpClient.put(`phones/${id}`, phone);
    }

    deletePhone(id: number): Observable<null> {
        return this.httpClient.delete(`phones/${id}`);
    }
}
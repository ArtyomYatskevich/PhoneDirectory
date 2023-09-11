import {Injectable} from '@angular/core';
import { Router } from '@angular/router';

import { AuthResponseModel } from '@core/models';
import { PhoneDirectoryHttpClient } from '@core/services';

import { ROUTES } from '../../../app-routing.module';

@Injectable({
    providedIn: 'root',
})
export class AuthService {
    private authKey = 'authAccessToken';

    get isAuthenticated(): boolean {
        const token = sessionStorage.getItem(this.authKey);
        return token != null;
    }

    constructor(
        private router: Router,
        private httpClient: PhoneDirectoryHttpClient) {}

    login(email: string, password: string): void {
        this.httpClient.post<AuthResponseModel>('auth/login', {email, password}).subscribe(data => {
            sessionStorage.setItem(this.authKey, data.token);
            this.router.navigate([`/${ROUTES.phoneDirectory}`]);
        })
    }

    logout(): void {
        this.httpClient.post('auth/logout').subscribe(_ => {
            sessionStorage.removeItem(this.authKey);
            this.router.navigate([`/${ROUTES.login}`]);
        })
    }
}

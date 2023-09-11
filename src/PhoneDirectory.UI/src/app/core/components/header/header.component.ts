import { Component } from '@angular/core';

import { AuthService } from '@core/services';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
    constructor(private authService: AuthService) {}

    isLoggedIn(): boolean {
        return this.authService.isAuthenticated;
    }

    logout(): void {
        this.authService.logout();
    }
}

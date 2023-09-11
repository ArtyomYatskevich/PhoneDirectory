import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService } from '@core/services';

import { ROUTES } from '../../../../app-routing.module';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent {
    hide = true;
    email = new FormControl('', [Validators.required, Validators.email]);
    password = new FormControl('', [Validators.required]);

    constructor(
        private authService: AuthService,
        private router: Router,
    ) { }

    login(email: string, password: string): void {
        if (!email || !password) {
          return;
        }
        
        this.authService.login(email, password);
        this.router.navigate([`/${ROUTES.phoneDirectory}`]);
    }
}

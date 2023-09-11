import { inject, NgModule } from '@angular/core';
import { Router, RouterModule, Routes } from '@angular/router';

import { AuthService } from '@core/services';

const AuthGuard = () => {
    if (inject(AuthService).isAuthenticated) {
        return true;
    }

    return inject(Router).navigateByUrl(`/${ROUTES.login}`);
}

export const ROUTES = {
    home: '',
    login: 'login',
    phoneDirectory: 'phone-directory',
}

const routes: Routes = [
    {
        path: ROUTES.home,
        redirectTo: ROUTES.phoneDirectory,
        pathMatch: 'full'
    },
    {
        path: ROUTES.phoneDirectory,
        loadChildren: () => import('./modules/phone-directory/phone-directory.module').then(m => m.PhoneDirectoryModule),
        canActivate: [AuthGuard]
    },
    {
        path: ROUTES.login,
        loadChildren: () => import('./modules/login/login.module').then(m => m.LoginModule)
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }

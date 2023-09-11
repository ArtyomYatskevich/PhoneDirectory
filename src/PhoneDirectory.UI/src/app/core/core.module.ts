import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';

import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';

import { AppConfigService, PhoneDirectoryHttpClient, PhoneDirectoryHttpClientCreator } from '@core/services';
import { ErrorHandlerInterceptor } from '@core/interceptors';
import { HeaderComponent } from '@core/components/header/header.component';

@NgModule({
    declarations: [
        HeaderComponent
    ],
    imports: [
        CommonModule,
        MatButtonModule,
        MatToolbarModule,
        HttpClientModule
    ],
    exports: [HeaderComponent],
    providers: [
        {
            provide: PhoneDirectoryHttpClient,
            useFactory: PhoneDirectoryHttpClientCreator,
            deps: [HttpClient, AppConfigService]
        },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: ErrorHandlerInterceptor,
            multi: true
        }
    ]
})
export class CoreModule { }

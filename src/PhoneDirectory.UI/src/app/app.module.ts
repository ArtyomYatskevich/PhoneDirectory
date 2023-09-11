import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from '@core/core.module';
import { AppConfigService } from '@core/services';
import { JwtInterceptor } from '@core/interceptors';

export function initializeApp(appConfig: AppConfigService): () => Promise<void> {
  return () => appConfig.load();
}


@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        CoreModule
    ],
    providers: [
        AppConfigService,
        {
            provide: APP_INITIALIZER,
            useFactory: initializeApp,
            deps: [AppConfigService],
            multi: true
        },
        { 
            provide: HTTP_INTERCEPTORS,
            useClass: JwtInterceptor,
            multi: true 
        }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }

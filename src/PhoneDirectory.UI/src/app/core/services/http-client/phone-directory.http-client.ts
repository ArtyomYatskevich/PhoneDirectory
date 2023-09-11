import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { AppConfigService, HttpClientBase } from '@core/services';

export function PhoneDirectoryHttpClientCreator(
    http: HttpClient,
    appConfig: AppConfigService
): PhoneDirectoryHttpClient {
    return new PhoneDirectoryHttpClient(http, appConfig);
}

@Injectable()
export class PhoneDirectoryHttpClient extends HttpClientBase {
    protected readonly apiUrl = this.appConfigService.settings.apiUrls.phoneDirectory;

    public constructor(http: HttpClient, private appConfigService: AppConfigService) {
        super(http);
    }
}

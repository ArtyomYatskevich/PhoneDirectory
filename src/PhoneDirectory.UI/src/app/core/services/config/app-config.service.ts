import { HttpBackend, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { AppConfig } from '@core/services';

@Injectable({
    providedIn: 'root'
})
export class AppConfigService {
    private http: HttpClient;

    public settings!: AppConfig;
    readonly jsonFile = `app-config.json`;

    constructor(private readonly httpHandler: HttpBackend) {
        this.http = new HttpClient(httpHandler);
    }

    load(): Promise<void> {
        return new Promise<void>((resolve, reject) => {
            this.http
                .get<AppConfig>(this.jsonFile)
                .toPromise()
                .then((value: AppConfig | undefined) => {
                    this.settings = <AppConfig>value;
                    resolve();
                })
                .catch((response: any) => {
                    reject(`Could not load file '${this.jsonFile}': ${JSON.stringify(response)}`);
                });
        });
    }
}

import { RequestOptions } from '@core/services';

export interface PostRequestOptions extends Omit<RequestOptions, 'responseType'> {
    responseType: 'text';
}

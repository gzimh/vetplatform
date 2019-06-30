import { RequestModel } from './request.model';

export interface BookingsRequestModel extends RequestModel {
    date:string,
    status:string[]
}
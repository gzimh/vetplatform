import { ResponseModel } from './response.model';

export interface BookingsResponseModel extends ResponseModel {
    payload: Booking[];
    hasMore: boolean;
}

export interface Booking {
    id:string,
    schedule: Date,
    scheduleTime: string,
    status: string,
    customer: Customer
}

export interface Customer {
    id: string,
    name:string
}
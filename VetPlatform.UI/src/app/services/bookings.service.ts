import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BookingsRequestModel } from '../models/bookings.request.model';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from '../../environments/environment'
import { BookingsResponseModel } from '../models/bookings.response.model';
import { ChangeStatusRequestModel } from '../models/change-status.request.model';
import { ResponseModel } from '../models/response.model';

@Injectable()
export class BookingsService {
    
    constructor(private http: HttpClient) {
    }

    public getBookings(requestModel: BookingsRequestModel) : Observable<BookingsResponseModel> {
        let statusFilter = "";
        requestModel.status.forEach(filter => {
            statusFilter += `&status=${filter}`
        });
        const url = `${environment.api}api/bookings?date=${requestModel.date}&skip=${requestModel.skip}&take=${requestModel.take}${statusFilter}`;
        return this.http.get<BookingsResponseModel>(url)
    }

    public changeBookingStatus(requestModel: ChangeStatusRequestModel) : Observable<ResponseModel> {
        const url = `${environment.api}api/bookings/status`;
        return this.http.put<ResponseModel>(url, requestModel);
    }
}
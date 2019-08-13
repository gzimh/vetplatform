import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BookingsRequestModel } from '../models/bookings.request.model';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from '../../environments/environment'
import { BookingsResponseModel } from '../models/bookings.response.model';
import { ChangeStatusRequestModel } from '../models/change-status.request.model';
import { ResponseModel } from '../models/response.model';
import { ScheduleOption } from '../models/schedule-option';
import { BookNowRequestModel } from '../models/book-now.request.model';

@Injectable()
export class BookingsService {

  constructor(private http: HttpClient) {
  }

  public getBookings(requestModel: BookingsRequestModel): Observable<BookingsResponseModel> {
    let statusFilter = "";
    requestModel.status.forEach(filter => {
      statusFilter += `&status=${filter}`
    });
    const url = `${environment.api}api/bookings?date=${requestModel.date}&skip=${requestModel.skip}&take=${requestModel.take}${statusFilter}`;
    return this.http.get<BookingsResponseModel>(url)
  }

  public changeBookingStatus(requestModel: ChangeStatusRequestModel): Observable<ResponseModel> {
    const url = `${environment.api}api/bookings/status`;
    return this.http.put<ResponseModel>(url, requestModel);
  }

  public getSchedule(date: string): Observable<ScheduleOption[]> {
    const url = `${environment.api}api/bookings/schedule?date=${date}`;
    return this.http.get<ScheduleOption[]>(url);
  }

  public bookNow(model: BookNowRequestModel): Observable<any> {
    const url = `${environment.api}api/bookings`;
    return this.http.post<any>(url, model);
  }

}

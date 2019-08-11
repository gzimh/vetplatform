import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegisterRequest } from '../register/register-request.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class RegisterService {

  constructor(private http: HttpClient) {
  }

  public save(requestModel: RegisterRequest): Observable<any> {
    return this.http.post<RegisterRequest>(`${environment.api}api/register`, requestModel);
  }
}

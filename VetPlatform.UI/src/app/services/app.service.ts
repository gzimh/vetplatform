import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AppService {
  constructor(private http: HttpClient) {
  }

  public getStoreInfo(): Observable<any> {
    return this.http.get<any>(`${environment.api}api/tenants`);
  }
}

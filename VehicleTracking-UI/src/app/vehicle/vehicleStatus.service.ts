import { VehicleStatus } from './vehicleStatus';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable()
export class VehicleStatusService {
  vehicleStatusList: VehicleStatus[] = [];

  constructor(private http: HttpClient) {}

  load(): void {
    this.find().subscribe(
      (result: any) => {
        this.vehicleStatusList = result;
      },
      (err) => {
        console.error('error loading', err);
      }
    );
  }

  find(): Observable<VehicleStatus[]> {
    const url = `${environment.baseUrl}/gateway/VehicleStatuses`;
    const headers = new HttpHeaders().set('Accept', 'application/json');

    const params = {};

    return this.http.get<VehicleStatus[]>(url, { params, headers });
  }
}

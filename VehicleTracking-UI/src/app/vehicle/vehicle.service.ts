import { Vehicle } from './vehicle';
import { FlightFilter } from './vehicle-filter';
import { Injectable } from '@angular/core';
import { EMPTY, Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable()
export class FlightService {
  flightList: Vehicle[] = [];
  totalItemCount = 0;

  constructor(private http: HttpClient) {}

  findById(id: string): Observable<Vehicle> {
    const url = `http://www.angular.at/api/vehicle/${id}`;
    const params = { id: id };
    const headers = new HttpHeaders().set('Accept', 'application/json');
    return this.http.get<Vehicle>(url, { params, headers });
  }

  load(filter: FlightFilter, pageSize: Number, pageNumber: Number = 1): void {
    this.find(filter, pageSize, pageNumber).subscribe(
      (result: any) => {
        this.totalItemCount = result.pageInformation?.totalItemCount;
        this.flightList = result.list;
      },
      (err) => {
        console.error('error loading', err);
      }
    );
  }

  find(
    filter: FlightFilter,
    pageSize: any,
    pageNumber: any
  ): Observable<Vehicle[]> {
    const url = `${environment.baseUrl}/gateway/Vehicles`;
    const headers = new HttpHeaders().set('Accept', 'application/json');

    const params = {
      pageSize: pageSize,
      pageNumber: pageNumber,
      customer: filter.customer,
      status: filter.status,
    };

    return this.http.get<Vehicle[]>(url, { params, headers });
  }
}

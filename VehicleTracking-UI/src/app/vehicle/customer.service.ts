import { Customer } from './customer';
import { FlightFilter } from './vehicle-filter';
import { Injectable } from '@angular/core';
import { EMPTY, Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable()
export class CustomerService {
  customerList: Customer[] = [];
  totalItemCount = 0;

  constructor(private http: HttpClient) {}

  load(filter: FlightFilter, pageSize: Number, pageNumber: Number = 1): void {
    this.find(filter, pageSize, pageNumber).subscribe(
      (result: any) => {
        this.totalItemCount = result.pageInformation?.totalItemCount;
        this.customerList = result.list;
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
  ): Observable<Customer[]> {
    const url = `${environment.baseUrl}/Customers`;
    const headers = new HttpHeaders().set('Accept', 'application/json');

    const params = {
      pageSize: pageSize,
      pageNumber: pageNumber,
      customer: filter.customer,
      status: filter.status,
    };

    return this.http.get<Customer[]>(url, { params, headers });
  }
}

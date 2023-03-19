import {
  Vehicle,
  VehicleFilter,
  VehicleStatusEnum,
  VehicleListResponse,
} from '../models';
import { SecondsAgo, ArrayLimit, ArraySkip } from '../../helpers';
import { Injectable } from '@angular/core';
import {
  of,
  skip,
  Observable,
  interval,
  toArray,
  mergeMap,
  BehaviorSubject,
} from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable()
export class VehicleService {
  private allVehicleList$ = new BehaviorSubject<Vehicle[] | null>([]);

  allVehicleList: Vehicle[] = [];
  vehicleList: Vehicle[] = [];

  defaultPageSize = 10;
  totalItemCount = 0;
  pageInformation: {
    filter: VehicleFilter;
    pageSize: Number;
    pageNumber: Number;
  } = {
    filter: new VehicleFilter(),
    pageSize: this.defaultPageSize,
    pageNumber: 1,
  };

  constructor(private http: HttpClient) {
    const $VehicleStatusWatcher = interval(10000);
    $VehicleStatusWatcher.pipe(skip(1)).subscribe(() => {
      this.emitAllChangedVehicleList(this.allVehicleList);
    });

    this.allVehicleList$.subscribe((x) => {
      this.allVehicleList = x || this.allVehicleList;

      let filteredVehicleList = this.filter(this.pageInformation.filter);

      this.vehicleList = this.paginateList(
        filteredVehicleList,
        +this.pageInformation.pageNumber,
        +this.pageInformation.pageSize
      );

      this.totalItemCount = filteredVehicleList.length;
    });

    this.fetchVehicles(new VehicleFilter(), 9999, 1).subscribe((x) => {
      this.emitAllChangedVehicleList(x.list);
    });
  }

  vehiclePingHandler(data: any) {
    this.emitAllChangedVehicleList(
      this.allVehicleList.map((x) => {
        if (x.id === data.vehicleId) {
          return {
            ...x,
            lastPing: data.date,
            vehicleStatusId: data.vehicleStatus,
          };
        }
        return x;
      })
    );
  }
  Search(): void {
    this.allVehicleList$.next(null);
  }

  private emitAllChangedVehicleList(vehicleList: Vehicle[]) {
    this.watchVehicles(vehicleList).subscribe((res) => {
      this.allVehicleList$.next(res);
    });
  }
  private filter(filter: VehicleFilter): Vehicle[] {
    return this.allVehicleList.filter(
      (x) =>
        (filter.status == '' ||
          (filter.status != '' &&
            (SecondsAgo(x.lastPing) <=
            environment.VehicleIsDisconnectedMins * 60
              ? VehicleStatusEnum.Connected
              : VehicleStatusEnum.Disconnected) == +filter.status)) &&
        (filter.customer.length == 0 ||
          filter.customer.find((c) => c == x.customerId))
    );
  }
  private paginateList(
    arr: any[],
    pageNumber: number,
    pageSize: number
  ): Vehicle[] {
    return ArrayLimit(ArraySkip(arr, (+pageNumber - 1) * +pageSize), +pageSize);
  }

  private fetchVehicles(
    filter: VehicleFilter,
    pageSize: any,
    pageNumber: any
  ): Observable<VehicleListResponse> {
    const url = `${environment.baseUrl}/Vehicles`;
    const headers = new HttpHeaders().set('Accept', 'application/json');

    const params = {
      pageSize: pageSize,
      pageNumber: pageNumber,
      customer: filter.customer,
      status: filter.status,
    };

    return this.http.get<VehicleListResponse>(url, { params, headers });
  }

  private watchVehicles = (vehicleList: Vehicle[]) => {
    return of(vehicleList).pipe(
      mergeMap((users) => users),
      mergeMap((vehicle: Vehicle) => {
        const updatedVehicle$: Observable<Vehicle> =
          this.mapLastVehicleChanges(vehicle);
        return updatedVehicle$;
      }),
      toArray()
    );
  };
  private mapLastVehicleChanges = (vehicle: Vehicle): Observable<Vehicle> => {
    return of({
      ...vehicle,
      vehicleStatusId:
        SecondsAgo(vehicle.lastPing) <=
        environment.VehicleIsDisconnectedMins * 60
          ? VehicleStatusEnum.Connected.toString()
          : VehicleStatusEnum.Disconnected.toString(),
    });
  };
}

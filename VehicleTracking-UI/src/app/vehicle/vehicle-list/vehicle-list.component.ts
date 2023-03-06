import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { FlightFilter } from '../vehicle-filter';
import { FlightService } from '../vehicle.service';
import { CustomerService } from '../customer.service';
import { VehicleStatusService } from '../vehicleStatus.service';
import { Vehicle } from '../vehicle';
import { Customer } from '../customer';
import { NumberInput } from '@angular/cdk/coercion';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { tap } from 'rxjs';

import { FormControl } from '@angular/forms';
import { VehicleStatus } from './../vehicleStatus';
import { MatOption } from '@angular/material/core';
import { MatSelect } from '@angular/material/select';
import { MatTableDataSource } from '@angular/material/table';
import { SignalrNotificationService } from 'src/app/services/signalr.notification.service';
@Component({
  selector: 'app-vehicle',
  templateUrl: 'vehicle-list.component.html',
  styles: [],
})
export class FlightListComponent implements OnInit {
  emptyData = new MatTableDataSource([{}]);

  //@ViewChild(MatPaginator) paginator: MatPaginator! = null;
  pageSize: any = 10;
  pageNumber: Number = 1;
  totalItemCount: any = 0;
  displayedColumns = [
    'id',
    'vin',
    'customerName',
    'vehicleStatusId',
    'lastPing',
    //'actions',
  ];
  filter = new FlightFilter();
  selectedFlight!: Vehicle;
  feedback: any = {};

  constructor(
    private changeDetector: ChangeDetectorRef,
    public signalRNotificationService: SignalrNotificationService,
    private flightService: FlightService,
    private customerService: CustomerService,
    private vehicleStatusService: VehicleStatusService
  ) {}
  handlePageEvent(event: PageEvent) {
    this.totalItemCount = event.length;
    this.pageSize = event.pageSize;
    this.pageNumber = +event.pageIndex + 1;
    this.flightService.load(this.filter, this.pageSize, this.pageNumber);
  }
  get flightList(): Vehicle[] {
    this.totalItemCount = this.flightService.totalItemCount;
    return this.flightService.flightList;
  }

  get customerList(): Customer[] {
    return this.customerService.customerList;
  }
  get vehicleStatusList(): VehicleStatus[] {
    return this.vehicleStatusService.vehicleStatusList;
  }
  toppings = new FormControl('');
  @ViewChild('matRef') matRef!: MatSelect;

  async ngOnInit() {
    await this.signalRNotificationService.startConnection();
    this.signalRNotificationService.addTransferNotificationsDataListener(
      (data: any) => {
        this.flightService.load(this.filter, this.pageSize, this.pageNumber);
        // this.flightService.flightList = this.flightService.flightList.map(
        //   (x) => {
        //     if (x.id === data.vehicleId) {
        //       return {
        //         ...x,
        //         lastPing: data.date,
        //         vehicleStatusId: data.vehicleStatus,
        //       };
        //     }
        //     return x;
        //   }
        // );
        this.changeDetector.detectChanges();
      }
    );
    this.customerService.load(this.filter, this.pageSize, this.pageNumber);
    this.vehicleStatusService.load();
    this.search();
  }

  search(): void {
    this.flightService.load(this.filter, this.pageSize, this.pageNumber);
  }
  clear(): void {
    this.matRef.options.forEach((data: MatOption) => data.deselect());
    this.pageNumber = 1;
    this.pageSize = 10;
    this.filter.customer = [];
    this.filter.status = '';
    this.flightService.load(this.filter, this.pageSize, this.pageNumber);
  }
  select(selected: Vehicle): void {
    this.selectedFlight = selected;
  }
}

import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { VehicleFilter } from '../models/vehicle-filter';
import { VehicleService } from '../services/vehicle.service';
import { CustomerService } from '../services/customer.service';
import { VehicleStatusService } from '../services/vehicleStatus.service';
import { Vehicle } from '../models/vehicle';
import { Customer } from '../models/customer';
import { PageEvent } from '@angular/material/paginator';
import { FormControl } from '@angular/forms';
import { VehicleStatus } from './../models/vehicleStatus';
import { MatOption } from '@angular/material/core';
import { MatSelect } from '@angular/material/select';
import { MatTableDataSource } from '@angular/material/table';
import { SignalrNotificationService } from 'src/app/services/signalr.notification.service';
@Component({
  selector: 'app-vehicle',
  templateUrl: 'vehicle-list.component.html',
  styles: [],
})
export class VehicleListComponent implements OnInit {
  defaultPageSize = 10;
  emptyData = new MatTableDataSource([{}]);
  totalItemCount: any = 0;
  displayedColumns = [
    'id',
    'vin',
    'customerName',
    'vehicleStatusId',
    'lastPing',
    //'actions',
  ];
  filter = new VehicleFilter();
  selectedVehicle!: Vehicle;
  feedback: any = {};

  constructor(
    private changeDetector: ChangeDetectorRef,
    public signalRNotificationService: SignalrNotificationService,
    public vehicleService: VehicleService,
    private customerService: CustomerService,
    private vehicleStatusService: VehicleStatusService
  ) {
    this.vehicleService.pageInformation = {
      filter: new VehicleFilter(),
      pageSize: this.defaultPageSize,
      pageNumber: 1,
    };
  }
  handlePageEvent(event: PageEvent) {
    this.vehicleService.pageInformation = {
      ...this.vehicleService.pageInformation,
      pageSize: event.pageSize,
      pageNumber: +event.pageIndex + 1,
    };
    this.vehicleService.Search();
  }
  get vehicleList(): Vehicle[] {
    this.totalItemCount = this.vehicleService.totalItemCount;
    return this.vehicleService.vehicleList;
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
        this.vehicleService.vehiclePingHandler(data);
        this.changeDetector.detectChanges();
      }
    );
    this.customerService.load(this.filter, 999, 1);
    this.vehicleStatusService.load();
  }

  search(): void {
    this.vehicleService.pageInformation = {
      ...this.vehicleService.pageInformation,
      filter: this.filter,
    };
    this.vehicleService.Search();
  }
  clear(): void {
    this.matRef.options.forEach((data: MatOption) => data.deselect());

    this.filter.customer = [];
    this.filter.status = '';
    this.vehicleService.pageInformation = {
      ...this.vehicleService.pageInformation,
      filter: this.filter,
      pageSize: this.defaultPageSize,
      pageNumber: 1,
    };
    this.vehicleService.Search();
  }
  select(selected: Vehicle): void {
    this.selectedVehicle = selected;
  }
}

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FlightListComponent } from './vehicle-list/vehicle-list.component';
import { FlightEditComponent } from './vehicle-edit/vehicle-edit.component';
import { FlightService } from './vehicle.service';
import { CustomerService } from './customer.service';
import { VehicleStatusService } from './vehicleStatus.service';
import { FLIGHT_ROUTES } from './vehicle.routes';
import { MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(FLIGHT_ROUTES),
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatSelectModule,
  ],
  declarations: [FlightListComponent, FlightEditComponent],
  providers: [FlightService, CustomerService, VehicleStatusService],
  exports: [FlightListComponent],
})
export class FlightModule {}

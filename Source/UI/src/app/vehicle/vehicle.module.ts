import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';
import { VehicleService } from './services/vehicle.service';
import { CustomerService } from './services/customer.service';
import { VehicleStatusService } from './services/vehicleStatus.service';
import { VEHICLE_ROUTES } from './vehicle.routes';
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
    RouterModule.forChild(VEHICLE_ROUTES),
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
  declarations: [VehicleListComponent],
  providers: [VehicleService, CustomerService, VehicleStatusService],
  exports: [VehicleListComponent],
})
export class VehicleModule {}

import { Routes } from '@angular/router';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';

export const VEHICLE_ROUTES: Routes = [
  {
    path: 'Vehicles',
    component: VehicleListComponent,
  },
  // {
  //   path: 'Vehicles/:id',
  //   component: VehicleEditComponent,
  // },
];

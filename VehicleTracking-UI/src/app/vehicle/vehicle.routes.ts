import { Routes } from '@angular/router';
import { FlightListComponent } from './vehicle-list/vehicle-list.component';
import { FlightEditComponent } from './vehicle-edit/vehicle-edit.component';

export const FLIGHT_ROUTES: Routes = [
  {
    path: 'flights',
    component: FlightListComponent,
  },
  {
    path: 'flights/:id',
    component: FlightEditComponent,
  },
];

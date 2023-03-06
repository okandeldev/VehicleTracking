import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { FlightService } from '../vehicle.service';
import { Vehicle } from '../vehicle';
import { map, switchMap } from 'rxjs/operators';
import { of } from 'rxjs';

@Component({
  selector: 'app-vehicle-edit',
  templateUrl: './vehicle-edit.component.html',
  styles: [],
})
export class FlightEditComponent implements OnInit {
  id!: string;
  vehicle!: Vehicle;
  feedback: any = {};

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private flightService: FlightService
  ) {}

  ngOnInit() {
    this.route.params
      .pipe(
        map((p: any) => p.id),
        switchMap((id) => {
          if (id === 'new') {
            return of(new Vehicle());
          }
          return this.flightService.findById(id);
        })
      )
      .subscribe(
        (vehicle) => {
          this.vehicle = vehicle;
          this.feedback = {};
        },
        (err) => {
          this.feedback = { type: 'warning', message: 'Error loading' };
        }
      );
  }

  cancel() {
    this.router.navigate(['/flights']);
  }
}

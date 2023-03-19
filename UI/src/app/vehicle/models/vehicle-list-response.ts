import { Vehicle } from './vehicle';

export class VehicleListResponse {
  list: Vehicle[] = [];
  pageInformation: {
    pageCount: number;
    pageSize: number;
    pageNumber: number;
    totalItemCount: number;
  };
}

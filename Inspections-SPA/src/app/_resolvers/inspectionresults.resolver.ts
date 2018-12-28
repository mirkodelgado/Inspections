import { AlertifyService } from './../_services/alertify.service';
import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { InspectionM } from '../_models/inspectionm';
import { InspectionService } from '../_services/inspection.service';

@Injectable()
export class InspectionresultsResolver implements Resolve<InspectionM[]> {

    pageNumber = 1;
    pageSize = 20;

    constructor(private inspectionService: InspectionService, private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<InspectionM[]> {
        return this.inspectionService.getInspections(this.inspectionService.getInspectionParams(), this.pageNumber, this.pageSize).pipe (
            catchError(error => {
                this.alertify.error('Problem retrieving inspection data');
                // this.alertify.error('Unable to find unit ' + this.inspectionService.getSearchUnit());
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}

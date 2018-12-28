import { AlertifyService } from './../_services/alertify.service';
import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { InspectionM } from '../_models/inspectionm';
import { InspectionService } from '../_services/inspection.service';

@Injectable()
export class InspectionDetailsResolver implements Resolve<InspectionM> {


    constructor(private inspectionService: InspectionService, private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<InspectionM> {
        return this.inspectionService.getInspectionDetails(route.params['id']).pipe (
            catchError(error => {
                this.alertify.error('Problem retrieving inspection ' + route.params['id']);
                this.router.navigate(['/app-inspections']);
                return of(null);
            })
        );
    }
}

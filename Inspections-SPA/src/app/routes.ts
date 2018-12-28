import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { InspectionsComponent } from './inspections/inspections.component';
import { InspectionDetailComponent } from './inspectionDetail/inspectionDetail.component';

import { InspectionresultsResolver } from './_resolvers/inspectionresults.resolver';
import { PicturesResolver } from './_resolvers/pictures.resolver';
import { InspectionDetailsResolver } from './_resolvers/inspectiondetails.resolver';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'app-inspections', component: InspectionsComponent, resolve: { inspection: InspectionresultsResolver } },
    { path: 'app-inspectionDetail/:id', component: InspectionDetailComponent,
            resolve: { clean: PicturesResolver } },
    // { path: 'app-inspectionDetail/:id', component: InspectionDetailComponent },
    { path: '**', redirectTo: 'home', pathMatch: 'full' },
];

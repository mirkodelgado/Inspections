import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { TabsModule, ComponentLoaderFactory, PositioningService, BsDatepickerModule } from 'ngx-bootstrap';
import { ModalModule } from 'ngx-bootstrap/modal';

import { NgxGalleryModule } from 'ngx-gallery';

import { AppComponent } from './app.component';
import { NavmenuComponent } from './navmenu/navmenu.component';
import { HomeComponent } from './home/home.component';
import { InspectionsComponent } from './inspections/inspections.component';

import { appRoutes } from './routes';

import { InspectionService } from './_services/inspection.service';
import { AlertifyService } from './_services/alertify.service';
import { InspectionresultsResolver } from './_resolvers/inspectionresults.resolver';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { InspectionDetailComponent } from './inspectionDetail/inspectionDetail.component';
import { PicturesResolver } from './_resolvers/pictures.resolver';
import { InspectionDetailsResolver } from './_resolvers/inspectiondetails.resolver';

@NgModule({
   declarations: [
      AppComponent,
      NavmenuComponent,
      HomeComponent,
      InspectionsComponent,
      InspectionDetailComponent
   ],
   imports: [
      BrowserModule,
      NgxDatatableModule,
      HttpClientModule,
      FormsModule,
      ModalModule.forRoot(),
      BsDatepickerModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      NgxGalleryModule
   ],
   providers: [
      InspectionService,
      AlertifyService,
      ErrorInterceptorProvider,
      InspectionresultsResolver,
      PicturesResolver,
      InspectionDetailsResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }

import { InspectionDetails } from './../_models/inspectionDetails';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from 'src/environments/environment';

import { InspectionM } from '../_models/inspectionm';
import { PaginatedResult } from '../_models/pagination';
import { PictureInfo } from '../_models/pictureInfo';

@Injectable({
  providedIn: 'root'
})
export class InspectionService {

  baseUrl = environment.apiUrl + 'inspection/';

  pictureInfo: PictureInfo;

  inspectionResults: InspectionM[];

  inspectionDetails: InspectionDetails[];

  inspectionM: InspectionM;

  inspectionParams: any = {};

  constructor(private http: HttpClient) { }

  getInspections(userParams, page?, itemsPerPage?,
    orderByColumn?, orderByDirection?): Observable<PaginatedResult<InspectionM[]>> {

    const paginatedResult: PaginatedResult<InspectionM[]> = new PaginatedResult<InspectionM[]>();

    let params = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    // console.log('orderByColumn: ' + orderByColumn);
    // console.log('orderByDirection: ' + orderByDirection);

    if (orderByColumn != null && orderByDirection != null) {
      params = params.append('orderByColumn', orderByColumn);
      params = params.append('orderByDirection', orderByDirection);
    }

    params = params.append('unitid', userParams.unitid);
    params = params.append('startDate', userParams.startDate);
    params = params.append('endDate', userParams.endDate);

    return this.http.get<InspectionM[]>(this.baseUrl + 'getinspections', { observe: 'response', params})
    // return this.http.get<InspectionM[]>(this.baseUrl + 'getinspections', { observe: 'response', params})
      .pipe(map(response => {

        console.log('response body: ' + response.body);

        this.inspectionResults = response.body;
        paginatedResult.result = response.body;

        if (response.headers.get('Pagination') != null) {
          paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }

        return paginatedResult;
        // return this.inspectionResults;
      })
    );
  }

  getCleanInspectionDetails(id): Observable<InspectionM> {

    console.log('getCleanInspectionDetails id: ' + id);

    return this.http.get<InspectionM>(this.baseUrl + 'getpictures/' + id, { observe: 'response' }).pipe(
        map((response: any) => {

        const inspectionInfo = response.body;

        if (inspectionInfo) {

          console.log('inspectionInfo.pictures: ' + inspectionInfo.pictures);
          console.log('inpsectionInfo.inspectionMToReturn: ' + inspectionInfo.inspectionMToReturn);

          this.pictureInfo = inspectionInfo.pictures;
          this.inspectionM = inspectionInfo.inspectionMToReturn;

          return this.inspectionM;

          // console.log('response body: ' + response.body);

          // this.gatesByEir = response.body;
          // return this.gatesByEir;

        }

      })
    );
  }

  getInspectionDetails(id): Observable<InspectionM> {

    console.log('getInspectionDetails id: ' + id);

    return this.http.get<InspectionM>(this.baseUrl + id, { observe: 'response' }).pipe(
        map((response: any) => {

        const inspectionInfo = response.body;

        if (inspectionInfo) {

          console.log('inspectionInfo.pictures: ' + inspectionInfo.pictures);
          console.log('inspectionInfo.inspectionMToReturn: ' + inspectionInfo.inspectionMToReturn);
          console.log('inpsectionInfo.inspectionDetails: ' + inspectionInfo.inspectionToReturn);

          this.pictureInfo = inspectionInfo.pictures;
          this.inspectionM = inspectionInfo.inspectionMToReturn;
          this.inspectionDetails = inspectionInfo.inspectionToReturn;

          return this.inspectionM;
        }

      })
    );
  }





  setInspectionParams(unitid: string, startDate: string, endDate: string) {
    this.inspectionParams.unitid = unitid;
    this.inspectionParams.startDate = startDate;
    this.inspectionParams.endDate = endDate;

    localStorage.setItem('unitid', unitid);
    localStorage.setItem('startDate', startDate);
    localStorage.setItem('endDate', endDate);
  }

  getInspectionParams(): any {
    this.inspectionParams.unitid = localStorage.getItem('unitid');
    this.inspectionParams.startDate = localStorage.getItem('startDate');
    this.inspectionParams.endDate = localStorage.getItem('endDate');

    console.log('unitid param: ' + this.inspectionParams.unitid);
    console.log('startDate param: ' + this.inspectionParams.startDate);
    console.log('endDate param: ' + this.inspectionParams.endDate);

    return this.inspectionParams;
  }

  setInspectionSortParams(orderByColumn: string, orderByDirection: string) {

    this.inspectionParams.ordeByColumn = orderByColumn;
    this.inspectionParams.ordeByDirection = orderByDirection;

    localStorage.setItem('ordeByColumn', orderByColumn);
    localStorage.setItem('ordeByDirection', orderByDirection);
  }

  getInspectionSortParams(): any {
    this.inspectionParams.orderByColumn = localStorage.getItem('orderByColumn');
    this.inspectionParams.orderByDirection = localStorage.getItem('orderByDirection');

    // console.log('orderByColumn param: ' + this.inspectionParams.orderByColumn);
    // console.log('orderByDirection param: ' + this.inspectionParams.orderByDirection);

    return this.inspectionParams;
  }

  setInspectionNumber(inspection: string) {
    localStorage.setItem('inspection', inspection);
  }

  setCleanInspection(inspection: string) {

    for (let i = 0; i < this.inspectionResults.length; i++) {
      if (this.inspectionResults[i].imInspectionRefNmbr === inspection) {
        localStorage.setItem('cleaninspection', this.inspectionResults[i].imCleanInspection);
      }
    }

  }

  getInspectionNumber(): string {
    return localStorage.getItem('inspection');
  }

  getCleanInspectionNumber(): string {
    return localStorage.getItem('cleaninspection');
  }

  getPicutreInfo(): PictureInfo {
    return this.pictureInfo;
  }

  getInsDetails(): InspectionDetails[] {
    return this.inspectionDetails;
  }


}





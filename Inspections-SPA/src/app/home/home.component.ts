import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { InspectionDetails } from '../_models/inspectionDetails';
import { Router } from '@angular/router';
import { InspectionService } from '../_services/inspection.service';
import { AlertifyService } from '../_services/alertify.service';
import { DateFormatter } from 'ngx-bootstrap';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private inspectionService: InspectionService, private alertifyService: AlertifyService, private router: Router) { }

  model: any = {};

  // daterange: Date[];
  // inspection: number;

  // searchMethod: string;

  ngOnInit() {
    this.model.searchMethod = '1';
  }

  searchByUnit(): boolean {

    if (this.model.searchMethod === '1') {
      return true;
    }

    return false;
  }

  onItemChange(item) {
    // console.log('item: ' + item);

    if (+item === 2) {
      this.model.inspectionUnit = '';
    } else {
      this.model.daterange = '';
    }
  }

  findInspection(form: NgForm) {

    // console.log(this.model);

    let startDate = '';
    let endDate = '';

    if (+this.model.searchMethod === 1) {
      console.log('inspectionUnit: ' + this.model.inspectionUnit);
    } else {
      console.log('daterange[0]: ' + this.model.daterange[0]);
      console.log('daterange[1]: ' + this.model.daterange[1]);

      startDate = this.model.daterange[0].getFullYear() + '-' +
                        ('0' + (this.model.daterange[0].getMonth() + 1)).slice(-2) + '-' +
                        ('0' + this.model.daterange[0].getDate()).slice(-2);

      endDate = this.model.daterange[1].getFullYear() + '-' +
                        ('0' + (this.model.daterange[1].getMonth() + 1)).slice(-2) + '-' +
                        ('0' + this.model.daterange[1].getDate()).slice(-2);

      console.log('startDate: ' + startDate);
      console.log('endDate: ' + endDate);

    }

    this.inspectionService.setInspectionParams(this.model.inspectionUnit, startDate, endDate);

    this.router.navigate(['app-inspections']);


  }
}

import { Component, OnInit } from '@angular/core';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';

import { InspectionService } from '../_services/inspection.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { InspectionM } from '../_models/inspectionm';
import { InspectionDetails } from '../_models/inspectionDetails';

@Component({
  selector: 'app-inspectionDetail',
  templateUrl: './inspectionDetail.component.html',
  styleUrls: ['./inspectionDetail.component.css']
})
export class InspectionDetailComponent implements OnInit {

  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  inspectionNumber: string;
  cleanInspection: string;

  inspectionM: InspectionM;
  inspectionDetails: InspectionDetails[];


  constructor(private route: ActivatedRoute, private alertify: AlertifyService, private inspectionService: InspectionService) { }

  ngOnInit() {

    this.inspectionNumber = this.inspectionService.getInspectionNumber();
    this.cleanInspection = this.inspectionService.getCleanInspectionNumber();

    console.log('inspectionNumber: ' + this.inspectionNumber);
    console.log('cleanInspection: ' + this.cleanInspection);

    // if (+this.cleanInspection === 1) {
      this.route.data.subscribe(data => {
        this.inspectionM = data['clean'];
      });
    // } else {
    //  this.route.data.subscribe(data => {
    //    this.inspectionM = data['details'];
    //  });
    // }

    if (+this.cleanInspection === 0) {
      this.inspectionDetails = this.inspectionService.getInsDetails();
    }


    this.galleryOptions = [
      {
        width: '500px',
        height: '500px',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: true,
        imageDescription: true
      }
    ];

    this.galleryImages = this.getImages();

  }

  getImages() {
    const imageUrls = [];

    const pictureInfo = this.inspectionService.getPicutreInfo();

    console.log('pictureInfo Length ' + pictureInfo.pictureUrl.length);

    for (let i = 0; i < pictureInfo.pictureUrl.length; i++) {
      imageUrls.push({
        small: pictureInfo.pictureUrl[i],
        medium: pictureInfo.pictureUrl[i],
        big: pictureInfo.pictureUrl[i],
        description: 'Taken on ' + pictureInfo.inDate
      });
    }

    // imageUrls.push ({
    //  small: 'http://cgi-dms.com/gp/308800/G01.jpg',
    //  medium: 'http://cgi-dms.com/gp/308800/G01.jpg',
    //  big: 'http://cgi-dms.com/gp/308800/G01.jpg',
    //  description: '308800 description'
    // });

    // imageUrls.push ({
    //  small: 'http://cgi-dms.com/gp/308800/signature.jpg',
    //  medium: 'http://cgi-dms.com/gp/308800/signature.jpg',
    //  big: 'http://cgi-dms.com/gp/308800/signature.jpg',
    //  description: 'signature description'
    // });

    return imageUrls;
  }

  isCleanInspection(): boolean {

    if (+this.inspectionM.imCleanInspection === 1) {
      return true;
    }

    return false;
  }



}

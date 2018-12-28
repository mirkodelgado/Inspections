import { Pagination, PaginatedResult } from './../_models/pagination';
import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { InspectionM } from '../_models/inspectionm';
import { InspectionService } from '../_services/inspection.service';
import { AlertifyService } from '../_services/alertify.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-inspections',
  templateUrl: './inspections.component.html',
  styleUrls: ['./inspections.component.css']
})
export class InspectionsComponent implements OnInit {

  inspectionResults: InspectionM[];
  pagination: Pagination;

  columns: any[] = [];
  rows = new Array<InspectionM>();

  @ViewChild('inspectionDateTemplate')
  inspectionDateTemplate: TemplateRef<any>;

  @ViewChild('inspectionClientTemplate')
  inspectionClientTemplate: TemplateRef<any>;

  @ViewChild('inspectionNumberTemplate')
  inspectionNumberTemplate: TemplateRef<any>;

  constructor(private inspectionService: InspectionService, private alertifyService: AlertifyService,
    private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {

    // [columns]="[ {prop:'imInspectionDate', name:'Inspection Date', sortable: false },
    // {prop:'imEquip1Id', name:'Unit ID', sortable: false},
    // {prop: 'imInspectionRefNmbr', name:'Inspection Number', sortable: false} ]"

    this.columns = [
                    {prop: 'imInspectionDate', name: 'Inspection Date', cellTemplate: this.inspectionDateTemplate, sortable: false },
                    {prop: 'billToClient.btcBillToClientShortName', name: 'Client',
                                cellTemplate: this.inspectionClientTemplate, sortable: false },
                    {prop: 'imEquip1Id', name: 'Unit ID', sortable: false},
                    {prop: 'imInspectionRefNmbr', name: 'Inspection Number', cellTemplate: this.inspectionNumberTemplate, sortable: false}
    ];


    this.route.data.subscribe(data => {
      this.inspectionResults = data['inspection'].result;
      this.pagination = data['inspection'].pagination;
      this.rows = this.inspectionResults;

      this.pagination.offset = this.pagination.currentPage - 1;
     });

    // this.gateUnitResults = this.gateService.getGateUnitResults();
  }

  setPage(pageInfo) {

    console.log('pageInfo.offset: ' + pageInfo.offset);
    this.pagination.currentPage = pageInfo.offset + 1;
    console.log('pagination.currentPage: ' + this.pagination.currentPage);

    this.loadInspections();
  }

  loadInspections() {
    this.inspectionService.getInspections(this.inspectionService.getInspectionParams(),
                                          this.pagination.currentPage, this.pagination.itemsPerPage)
    .subscribe(
      (res: PaginatedResult<InspectionM[]>) => {
        this.inspectionResults = res.result;
        this.pagination = res.pagination;

        this.pagination.offset = this.pagination.currentPage - 1;

        this.rows = this.inspectionResults;
      },
        error => {
          this.alertifyService.error(error);
        }
    );
  }


  getInspection(inspectionNumber: string) {
    console.log('inspection: ' + inspectionNumber);

    this.inspectionService.setInspectionNumber(inspectionNumber);

    this.inspectionService.setCleanInspection(inspectionNumber);

    this.router.navigate(['app-inspectionDetail/' + inspectionNumber]);

  }
}

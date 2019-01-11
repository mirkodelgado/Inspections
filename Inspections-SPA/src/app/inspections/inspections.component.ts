import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { InspectionM } from '../_models/inspectionm';
import { Pagination, PaginatedResult } from './../_models/pagination';

import { AlertifyService } from '../_services/alertify.service';
import { InspectionService } from '../_services/inspection.service';

@Component({
  selector: 'app-inspections',
  templateUrl: './inspections.component.html',
  styleUrls: ['./inspections.component.css']
})
export class InspectionsComponent implements OnInit {

  loading: boolean;

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
                    { prop: 'imInspectionDate', name: 'Inspection Date', cellTemplate: this.inspectionDateTemplate, sortable: true },
                    { prop: 'depot.dptName', name: 'Location', sortable: true },

                    { prop: 'billToClient.btcBillToClientShortName', name: 'Client',
                                cellTemplate: this.inspectionClientTemplate, sortable: true },
                    { prop: 'imEquip1Id', name: 'Unit ID', sortable: true },
                    { prop: 'imInspectionRefNmbr', name: 'Inspection Number', cellTemplate: this.inspectionNumberTemplate, sortable: true }
    ];

    this.loading = true;

    this.route.data.subscribe(data => {
      this.inspectionResults = data['inspection'].result;
      this.pagination = data['inspection'].pagination;
      this.rows = this.inspectionResults;

      this.pagination.offset = this.pagination.currentPage - 1;
     });

     this.loading = false;

    // this.gateUnitResults = this.gateService.getGateUnitResults();
  }

  setPage(pageInfo) {

    console.log('pageInfo.offset: ' + pageInfo.offset);
    this.pagination.currentPage = pageInfo.offset + 1;
    console.log('pagination.currentPage: ' + this.pagination.currentPage);

    const sortParams = this.inspectionService.getInspectionSortParams();

    this.loadInspections(sortParams.orderByColumn, sortParams.orderByDirection);
  }

  onSort(event) {

    const sort = event.sorts[0];

    this.inspectionService.setInspectionSortParams(sort.dir, sort.prop);

    this.loadInspections(sort.prop, sort.dir);

    console.log('sort: ' + JSON.stringify(sort));
    // sort: {"dir":"asc","prop":"imInspectionDate"}
  }

  loadInspections(orderByColumn: string, orderByDirection: string) {

    this.loading = true;

    this.inspectionService.getInspections(this.inspectionService.getInspectionParams(),
                                          this.pagination.currentPage, this.pagination.itemsPerPage, orderByColumn, orderByDirection)
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

    this.loading = false;

  }


  getInspection(inspectionNumber: string) {
    console.log('inspection: ' + inspectionNumber);

    this.inspectionService.setInspectionNumber(inspectionNumber);

    this.inspectionService.setCleanInspection(inspectionNumber);

    this.router.navigate(['app-inspectionDetail/' + inspectionNumber]);

  }
}

import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-navmenu',
  templateUrl: './navmenu.component.html',
  styleUrls: ['./navmenu.component.css']
})
export class NavmenuComponent implements OnInit {
  modalRef: BsModalRef;

  navbarOpen = false;

  config = {
    animated: true
  };

  crDate = new Date().getFullYear();      // get current year for footer copyright


  constructor(private modalService: BsModalService) { }

  ngOnInit() {
  }

  openModal(template: TemplateRef<any>) {
      this.modalRef = this.modalService.show(template, this.config);
    }

    toggleNavbar() {
      this.navbarOpen = !this.navbarOpen;
    }

}

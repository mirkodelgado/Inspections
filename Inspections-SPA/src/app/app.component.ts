import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Inspections-SPA';

  crDate = new Date().getFullYear();      // get current year for footer copyright
}

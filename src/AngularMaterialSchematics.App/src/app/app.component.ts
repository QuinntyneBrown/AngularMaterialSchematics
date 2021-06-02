import { Component } from '@angular/core';
import { ContactService } from '@api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(
    private readonly _contactService: ContactService
  ) {

  }
}

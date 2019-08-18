import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  public contacts: Array<any>;
  p: number = 1;
  constructor(private http: HttpClient) {
    this.http.get('/api/Contact').subscribe(result => {
      this.contacts = result as Array<any>;
    }, error => console.error(error));
  }
}

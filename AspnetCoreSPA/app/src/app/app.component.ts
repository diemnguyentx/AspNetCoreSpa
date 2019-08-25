import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Contact List';
  public contacts: Array<any>;
  p: number = 1;

  public term: string; 

  constructor(private http: HttpClient) {
    this.search('');
  }

  search(term: string, pageNumber: number = 0) {
    this.term = term;

    this.http.get('/api/Contact', { params: { term: term, pageNumber: pageNumber.toString(), pageSize: "10" } })
      .subscribe(result => {
      this.contacts = result as Array<any>;
    }, error => console.error(error));
  }

  gotoPage(pageNumber: number) {
    this.search(this.term, pageNumber);
  }
}

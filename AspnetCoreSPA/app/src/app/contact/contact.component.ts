import { Component, OnInit } from '@angular/core';
import { ContactService } from '../contact.service';
@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  public pageNumber: number = 0;
  public term: string = '';
  public contacts: Array<any>;
  public pages: Array<number>

  constructor(private contactService: ContactService) { }

  ngOnInit() {
    this.getContacts();
  }
  setPage(i, event: any) {
    event.preventDefault();
    this.pageNumber = i;
    this.getContacts();
  }

  nextPage(event: any) {
    event.preventDefault();
    this.pageNumber = this.pageNumber + 1;
    this.getContacts();
  }
  prevPage(event: any) {
    event.preventDefault();
    if (this.pageNumber > 0) {
      this.pageNumber = this.pageNumber - 1;
    }
    this.getContacts();
  }
  serchContacts() {
    this.contactService.getContacts(this.term, this.pageNumber = 0)
      .subscribe(result => {
        this.contacts = result as Array<any>;
      }, error => console.error(error));
  }
  getContacts() {
    this.contactService.getContacts(this.term, this.pageNumber)
      .subscribe(result => {
        this.contacts = result as Array<any>;
        this.pages = new Array(5);
      }, error => console.error(error));
  }
}

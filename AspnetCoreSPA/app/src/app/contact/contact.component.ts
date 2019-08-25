import { Component, OnInit } from '@angular/core';
import { ContactService } from '../contact.service';
@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  public pageNumber: number = 1;
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

  serchContacts() {
    this.contactService.getContacts(this.term, this.pageNumber = 1)
      .subscribe(result => {
        this.contacts = result['contactList'];
      }, error => console.error(error));
  }

  getContacts() {
    this.contactService.getContacts(this.term, this.pageNumber)
      .subscribe(result => {
        //console.log(result);
        this.contacts = result['contactList'];
        this.pages = new Array(result['totalPages']);
      }, error => console.error(error));
  }

}


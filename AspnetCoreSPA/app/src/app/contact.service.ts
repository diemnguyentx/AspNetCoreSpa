import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http: HttpClient) { }
  getContacts(term: string, pageNumber: number) {
    return this.http.get('/api/Contact', { params: { term: term, pageNumber: pageNumber.toString()} });
  }
}

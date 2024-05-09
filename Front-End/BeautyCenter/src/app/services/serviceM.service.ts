import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Service } from '../_model/service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  baseurl="https://localhost:7206/api/Services"
  constructor(public http:HttpClient) { }
  getall(){
    return this.http.get<Service[]>(this.baseurl);
  }
  getById(id: number): Observable<Service> {
    const url = `${this.baseurl}/${id}`;
    return this.http.get<Service>(url);
  }
  
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Service } from '../_model/service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  baseurl="http://localhost:5240/api/Services"
  baseurl_Rana="http://localhost:5240/api/Services"

  constructor(public http:HttpClient) { }
  getall(){
    return this.http.get<Service[]>(this.baseurl);
  }
  getById(id: number): Observable<Service> {
    const url = `${this.baseurl}/${id}`;
    return this.http.get<Service>(url);
  }
  
  getAllCategories(){
    return this.http.get<string[]>(`${this.baseurl_Rana}/AllCategories`)
  }
}

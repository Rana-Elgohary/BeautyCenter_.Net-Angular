import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ServiceUser } from '../_model/service-user';

@Injectable({
  providedIn: 'root'
})
export class ServiceUserService {

  baseUrl="https://localhost:7206/api/UserService/";

  constructor(public http:HttpClient) { }

  getall(){
   return this.http.get<ServiceUser[]>(this.baseUrl);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ServiceUser } from '../_model/service-user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServiceUserService {

  baseUrl="https://localhost:7206/api/UserService";
  baseUrlForGetByUserID="https://localhost:7206/api/UserService/by-user";

  constructor(public http:HttpClient) { }

  getall(){
   return this.http.get<ServiceUser[]>(this.baseUrl);
  }

  getByUserId(id: number) {
    const url = `${this.baseUrlForGetByUserID}/${id}`;
    return this.http.get<ServiceUser[]>(url);
  }

  deleteById(userId: number, serviceId: number){
    console.log(`${this.baseUrl}/${userId}/${serviceId}`);
    return this.http.delete<"any">(`${this.baseUrl}/${userId}/${serviceId}`);
  }

  deleteAllServiceInThisUser(userId:number){
    return this.http.delete<"any">(`${this.baseUrl}/${userId}`);
  }
}

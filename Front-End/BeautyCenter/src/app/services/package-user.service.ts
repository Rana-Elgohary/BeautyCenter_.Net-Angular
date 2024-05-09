import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PackageUser } from '../_model/package-user';

@Injectable({
  providedIn: 'root'
})
export class PackageUserService {

  baseurl ="https://localhost:7206/api/PackageUser/"; //step2 to connect to db
  constructor(public http:HttpClient) { }
  getall(){
    return this.http.get<PackageUser[]>(this.baseurl);  //step3 to connect to db
  }
}

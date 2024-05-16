import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PackageUser } from '../_model/package-user';

@Injectable({
  providedIn: 'root'
})
export class PackageUserService {

  baseurl ="https://localhost:7206/api/PackageUser/"; //step2 to connect to db
  baseUrlForGetByUserID="https://localhost:7206/api/PackageUser/api/packages-by-user";
  constructor(public http:HttpClient) { }
  getall(){
    return this.http.get<PackageUser[]>(this.baseurl);  //step3 to connect to db
  }
  getByUserId(id: number) {
    const url = `${this.baseUrlForGetByUserID}/${id}`;
    return this.http.get<PackageUser[]>(url);
  }
  deleteById(userId: number, packageId: number){
    console.log(`${this.baseurl}${userId}/${packageId}`);
    return this.http.delete<"any">(`${this.baseurl}${userId}/${packageId}`);
  }
  deleteAllpackagesuserByUserId(userId: number){
    console.log(`${this.baseurl}${userId}`);
    return this.http.delete<"any">(`${this.baseurl}${userId}`);
  }
}

import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PackageUser } from '../_model/package-user';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

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
    const url = `${this.baseurl}${userId}/${packageId}`;
    return this.http.delete(url, { responseType: 'text' }).pipe(
      catchError(this.handleError)
    );
  }  
  

  deleteAllpackagesuserByUserId(userId: number): Observable<any> {
    const url = `${this.baseurl}${userId}`;
    return this.http.delete(url, { responseType: 'text' }).pipe(
      catchError(this.handleError)
    );
  }
  private handleError(error: HttpErrorResponse): Observable<never> {
    console.error('An error occurred:', error);
    return throwError('Something went wrong; please try again later.');
  }
}

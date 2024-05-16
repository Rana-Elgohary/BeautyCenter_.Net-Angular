import { Component, OnInit } from '@angular/core';
import { PackageUser } from '../../../_model/package-user';
import { PackageUserService } from '../../../services/package-user.service';
import { ActivatedRoute } from '@angular/router';
import { forkJoin } from 'rxjs';
import { PackageService } from '../../../services/package.service';
import { Package } from '../../../_model/package';
import { PriceCountService } from '../../../services/price-count.service';

@Component({
  selector: 'app-cart-packages',
  standalone: true,
  imports: [],
  templateUrl: './cart-packages.component.html',
  styleUrl: './cart-packages.component.css'
})
export class CartPackagesComponent implements OnInit{

  packageUser:PackageUser[]=[];
  packageM:Package[]=[];
  priceCounter:number=0;
  userId:number=0;

  constructor(public packageUserSERV:PackageUserService ,public ActivateRoute:ActivatedRoute ,public PriceService:PriceCountService,public packageService:PackageService){

  }
  ngOnInit(): void {
    this.ActivateRoute.params.subscribe(params=>{
      this.userId=params['userId'];

    this.packageUserSERV.getByUserId(this.userId).subscribe(data=>{
      this.packageUser=data;
      
      console.log(this.packageUser)  
      const requests = this.packageUser.map(element => {
        return this.packageService.GetPackageByID(element.packageId);
      });

      forkJoin(requests).subscribe((responses: Package[]) => {
        responses.forEach((response, index) => {
          this.packageUser[index].packagInfo = response;
          this.priceCounter +=+response.price; // Accumulate price
          // this.PriceService.priceCounter+=+this.priceCounter;
          // console.log("price is", this.priceCounter);       
         });
         this.PriceService.setPriceCounter(this.priceCounter); // Update the total price once
         console.log("price is", this.priceCounter);
      });
    });
  });
}

deleteById(userId:number,packageId:number){
  this.packageUserSERV.deleteById(userId,packageId)
}
}




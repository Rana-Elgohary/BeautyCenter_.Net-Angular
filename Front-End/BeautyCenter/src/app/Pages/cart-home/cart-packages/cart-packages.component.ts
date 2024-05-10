import { Component, OnInit } from '@angular/core';
import { PackageUser } from '../../../_model/package-user';
import { PackageUserService } from '../../../services/package-user.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-cart-packages',
  standalone: true,
  imports: [],
  templateUrl: './cart-packages.component.html',
  styleUrl: './cart-packages.component.css'
})
export class CartPackagesComponent implements OnInit{

  packageUser:PackageUser[]=[];
  userId!:number;
  constructor(public packageUserSERV:PackageUserService ,public ActivateRoute:ActivatedRoute ){

  }
  ngOnInit(): void {
    console.log("hi");
    this.ActivateRoute.params.subscribe(params=>{
      this.userId=params['userId'];
   
    this.packageUserSERV.getByUserId(this.userId).subscribe(data=>{
      this.packageUser=data;
      console.log(this.packageUser)  })
    })

    }

}

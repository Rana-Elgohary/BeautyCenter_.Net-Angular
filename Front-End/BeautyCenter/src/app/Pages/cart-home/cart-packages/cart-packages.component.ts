import { Component, OnInit } from '@angular/core';
import { PackageUser } from '../../../_model/package-user';
import { PackageUserService } from '../../../services/package-user.service';

@Component({
  selector: 'app-cart-packages',
  standalone: true,
  imports: [],
  templateUrl: './cart-packages.component.html',
  styleUrl: './cart-packages.component.css'
})
export class CartPackagesComponent implements OnInit{

  packageUser:PackageUser[]=[];
  constructor(public packageUserSERV:PackageUserService ){

  }
  ngOnInit(): void {
    console.log("hi");
    this.packageUserSERV.getall().subscribe(data=>{
      this.packageUser=data;
      console.log(this.packageUser)  })
    

    }

}

import { Component, OnInit } from '@angular/core';
import { PackageUser } from '../../_model/package-user';
import { PackageUserService } from '../../services/package-user.service';
import { ServiceUserService } from '../../services/service-user.service';
import { ServiceUser } from '../../_model/service-user';
import { CartSevicesComponent } from './cart-sevices/cart-sevices.component';
import { CartPackagesComponent } from './cart-packages/cart-packages.component';

@Component({
  selector: 'app-cart-home',
  standalone: true,
  imports: [CartSevicesComponent,CartPackagesComponent],
  templateUrl: './cart-home.component.html',
  styleUrl: './cart-home.component.css'
})
export class CartHomeComponent implements OnInit{

  packageUser:PackageUser[]=[];
  constructor(){

  }
  ngOnInit(): void {
    console.log("hela");
    
    }

}

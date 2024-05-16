import { Component, OnInit } from '@angular/core';
import { PackageUser } from '../../_model/package-user';
import { PackageUserService } from '../../services/package-user.service';
import { ServiceUserService } from '../../services/service-user.service';
import { ServiceUser } from '../../_model/service-user';
import { CartSevicesComponent } from './cart-sevices/cart-sevices.component';
import { CartPackagesComponent } from './cart-packages/cart-packages.component';
import { PriceCountService } from '../../services/price-count.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-cart-home',
  standalone: true,
  imports: [CartSevicesComponent, CartPackagesComponent],
  templateUrl: './cart-home.component.html',
  styleUrls: ['./cart-home.component.css']
})
export class CartHomeComponent implements OnInit {
  totalPrice: number = 0;
  userId: number = 0;

  constructor(
    public priceService: PriceCountService,
    public ActivateRoute: ActivatedRoute,
    public router: Router,
    public UserServService: ServiceUserService,
    public packageUserService: PackageUserService
  ) {}

  ngOnInit(): void {
    this.ActivateRoute.params.subscribe(params => {
      this.userId = params['userId'];
    });

    // Subscribe to the priceCounter$ observable
    this.priceService.priceCounter$.subscribe(price => {
      this.totalPrice = price;
      console.log('Total price is', this.totalPrice);
    });
  }

  confirm(): void {
    alert('Your book is confirmed');
    this.router.navigate(['/home']);
  }

  DeleteThisPayment(): void {
    this.UserServService.deleteAllServiceInThisUser(this.userId);
    this.packageUserService.deleteAllpackagesuserByUserId(this.userId);
    alert('Your book is deleted');
    this.router.navigate(['/home']);
  }
}

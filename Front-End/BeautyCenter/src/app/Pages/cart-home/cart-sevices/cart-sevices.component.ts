import { Component, OnInit } from '@angular/core';
import { ServiceUser } from '../../../_model/service-user';
import { PackageUserService } from '../../../services/package-user.service';
import { ServiceUserService } from '../../../services/service-user.service';
import { Service } from '../../../_model/service';
import { ServiceService } from '../../../services/serviceM.service';
import { forkJoin } from 'rxjs';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { PriceCountService } from '../../../services/price-count.service';

@Component({
  selector: 'app-cart-sevices',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './cart-sevices.component.html',
  styleUrls: ['./cart-sevices.component.css'] // Fixed typo
})
export class CartSevicesComponent implements OnInit {

  servUserM: ServiceUser[] = [];
  ServM: Service[] = [];
  userId!: number;
  priceCounter: number = 0;

  constructor(
    public serviceUse: ServiceUserService,
    public priceService: PriceCountService, // Fixed typo
    public servServ: ServiceService,
    public ActivatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.ActivatedRoute.params.subscribe(params => {
      this.userId = params['userId'];

      this.serviceUse.getByUserId(this.userId).subscribe(data => {
        this.servUserM = data;

        console.log(this.servUserM);

        const requests = this.servUserM.map(element => {
          return this.servServ.getById(element.serviceId);
        });

        forkJoin(requests).subscribe((responses: Service[]) => {
          responses.forEach((response, index) => {
            this.servUserM[index].serviceInfo = response;
            this.priceCounter += +this.servUserM[index].serviceInfo.price; // Accumulate price
          });
          this.priceService.setPriceCounter(this.priceCounter); // Update the total price once
          console.log("price is", this.priceCounter);
        });
      });
    });
  }

  deletePackage(userID: number, serviceID: number) {
    this.serviceUse.deleteById(userID, serviceID).subscribe(() => {
      this.priceCounter -= this.servUserM.find(su => su.serviceId === serviceID)?.serviceInfo?.price || 0;
      this.priceService.setPriceCounter(this.priceCounter); // Update the total price
    });
  }
}

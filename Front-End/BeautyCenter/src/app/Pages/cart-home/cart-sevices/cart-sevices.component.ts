import { Component, OnInit } from '@angular/core';
import { ServiceUser } from '../../../_model/service-user';
import { PackageUserService } from '../../../services/package-user.service';
import { ServiceUserService } from '../../../services/service-user.service';
import { Service } from '../../../_model/service';
import { ServiceService } from '../../../services/serviceM.service';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-cart-sevices',
  standalone: true,
  imports: [],
  templateUrl: './cart-sevices.component.html',
  styleUrl: './cart-sevices.component.css'
})
export class CartSevicesComponent implements OnInit{

  servUserM:ServiceUser[]=[];
  ServM:Service[]=[];
  constructor(public serviceUse:ServiceUserService ,public servServ:ServiceService){

  }
  ngOnInit(): void {
    this.serviceUse.getall().subscribe(data => {
      this.servUserM = data;
      console.log(this.servUserM);

      const requests = this.servUserM.map(element => {
        return this.servServ.getById(element.serviceId);
      });

      forkJoin(requests).subscribe((responses: Service[]) => {
        responses.forEach((response, index) => {
          this.servUserM[index].serviceInfo = response;
        });
      });
    });
  }
}
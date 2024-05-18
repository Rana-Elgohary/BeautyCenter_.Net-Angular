import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../../../services/serviceM.service';
import { ActivatedRoute } from '@angular/router';
import { Service } from '../../../_model/service';
import { Subscription } from 'rxjs';
import { ServiceUserService } from '../../../services/service-user.service';
import { ServiceUser } from '../../../_model/service-user';
import { UserService2 } from '../../../_model/user-service2';

@Component({
  selector: 'app-services-list',
  standalone: true,
  imports: [],
  templateUrl: './services-list.component.html',
  styleUrl: './services-list.component.css'
})
export class ServicesListComponent implements OnInit{

constructor(public serviceOfServices:ServiceService, public activatedRoute:ActivatedRoute, public serviceOfUserService:ServiceUserService){}
serviceList:Service[]=[];
serviceSub: Subscription|null=null;
category:any="";

userService: UserService2= new UserService2(0,0,"2024-04-20T00:00:00");

ngOnInit(): void {
  this.serviceSub=this.activatedRoute.params.subscribe({
    next:(data)=>
      {
        this.serviceOfServices.getByCategory(data["category"]).subscribe({
          next:(serviceData)=>{
            this.serviceList=serviceData;
            console.log(this.serviceList);
          }
        });
      }
  })
}

addService(ServiceId:number){
  this.userService.UserId=1;
  this.userService.ServiceId=ServiceId;

  this.serviceOfServices.addServiceUser(this.userService).subscribe({
    next:()=>{
      console.log("data")
    }
  });
}
ngOnDestroy(){
  this.serviceSub?.unsubscribe();
}
}

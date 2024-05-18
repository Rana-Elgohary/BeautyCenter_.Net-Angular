import { Component, OnInit } from '@angular/core';
import { PackageService } from '../../../../services/package.service';
import { Package } from '../../../../_model/package';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { PackageUserService } from '../../../../services/package-user.service';
import { PackageUser } from '../../../../_model/package-user';
import { PackageUserr2 } from '../../../../_model/package-userr2';
import { FormsModule } from '@angular/forms';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-package-list',
  standalone: true,
  imports: [RouterLink,FormsModule,],
  templateUrl: './package-list.component.html',
  styleUrl: './package-list.component.css'
})
export class PackageListComponent implements OnInit{
  constructor(public packgservice:PackageService,public packageuser:PackageUserService, public activateroute:ActivatedRoute){}
  packges:Package[]=[];
  userIdFromURL:number=1;

  ngOnInit(){
    this.packgservice.GetAllPackage().subscribe({
      next:(data)=>this.packges=data,
    })
    // this.activateroute.params.subscribe(p=>
    //   this.userIdFromURL=p['id']
    // )
  }
  ShowDate(str:string){
    var x = document.getElementById(str);
    if(x==null){

    }else{
    if(x.classList.contains("invisible")){
      x.classList.replace("invisible","visible")
    }else{
      x.classList.replace("visible","invisible")
    }
    console.log("ddsds")
    }
    
  }
  NewPackageUser:PackageUserr2=new PackageUserr2(this.userIdFromURL,0,"","","salma")
  setPackageId(id:number){
    this.NewPackageUser.packageId=id;
    console.log(this.NewPackageUser.packageId);
  }
  setPackageName(name:string){
    this.NewPackageUser.packageName=name;
    console.log(this.NewPackageUser.packageName)
  }
  AddPackageUser(){
    this.packageuser.AddPackageUser(this.NewPackageUser).subscribe(d=>{
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Password must be at least 8 characters long!',
      });
    })
  }
}
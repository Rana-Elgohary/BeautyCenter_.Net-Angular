import { Component, OnInit } from '@angular/core';
import { PackageService } from '../../../../services/package.service';
import { Package } from '../../../../_model/package';
import { RouterLink } from '@angular/router';


@Component({
  selector: 'app-package-list',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './package-list.component.html',
  styleUrl: './package-list.component.css'
})
export class PackageListComponent implements OnInit{
  constructor(public packgservice:PackageService){}
  packges:Package[]=[];
  ngOnInit(){
    this.packgservice.GetAllPackage().subscribe({
      next:(data)=>this.packges=data,
    })
  }
}

import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../../../services/serviceM.service';
import { Subscription } from 'rxjs';
import { HeroComponent } from '../hero/hero.component';
import { AboutUsComponent } from '../about-us/about-us.component';
import { CategoriesComponent } from '../categories/categories.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [HeroComponent, AboutUsComponent, CategoriesComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent{
  constructor(public serv:ServiceService){}

  sub:Subscription|null = null

  ngOnInit(){
    this.sub = this.serv.getAllCategories().subscribe({
      next:(data) => {
        console.log(data)
      }
    })
  }

  ngOnDestroy(){
    this.sub?.unsubscribe()
  }
}

import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CartHomeComponent } from './Pages/cart-home/cart-home.component';
import { HomeComponent } from './Pages/LandingPage/home/home.component';
import { HeaderComponent } from './Core/header/header.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,HomeComponent,HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'BeautyCenter';
}

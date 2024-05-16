import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
// import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, HttpClientModule, RouterModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']  // Corrected styleUrls to stylesUrls
})
export class LoginComponent{

  constructor(
    public http: HttpClient) {}

  name:String=""
  pass:String=""

  login() {
    const loginUrl = `http://localhost:5240/api/Login?username=${this.name}&pass=${this.pass}`;
    this.http.get(loginUrl, { responseType: 'text' })
    .subscribe({
      next: (response) => {
        const token = response;
        if (token) {
          console.log(token);
        }
      },
      error: (error) => {
        console.log(error);
      }
    });
  }
}
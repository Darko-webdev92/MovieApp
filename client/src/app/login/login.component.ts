import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginModel } from '../models/LoginModel';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  loginForm = new FormGroup({
    Username: new FormControl(),
    Password: new FormControl()
  })


  constructor(private authService: AuthService,
    private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit() {

    let usernameValue = this.loginForm.value.Username;
    let passwordValue = this.loginForm.value.Password;

    let loginModel = new LoginModel(usernameValue, passwordValue)

    this.authService.login(loginModel).subscribe({
      next: data => {
        localStorage.setItem("id", data.Id)
        localStorage.setItem("fullname", `${data.FirstName} ${data.LastName}`)
        localStorage.setItem("token", data.Token)
      },
      error: err => console.warn(err.error),
      complete: () => {
        this.router.navigate(["Home"])
      }
    })
  }
}

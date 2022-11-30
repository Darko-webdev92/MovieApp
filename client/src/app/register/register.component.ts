import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterModel } from '../models/RegisterModel';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

registerForm = new FormGroup({
  FirstName: new FormControl(),
  LastName: new FormControl(),
  Username: new FormControl(),
  Password: new FormControl(),
  ConfirmPassword: new FormControl()
})
  constructor(private authService: AuthService,  private router: Router) { }

  ngOnInit(): void {
  }

  OnSubmit(){
    let registerModel = new RegisterModel(
      this.registerForm.value.FirstName,
      this.registerForm.value.LastName,
      this.registerForm.value.Username,
      this.registerForm.value.Password,
      this.registerForm.value.ConfirmPassword
    )

    this.authService.register(registerModel).subscribe({
      next: data => console.log(data),
      error: err => console.warn(err.error),
      complete: () => {
        this.router.navigate(["/login"])
      }
  })
  }
}

import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { LoginModel } from "../models/LoginModel";
import { RegisterModel } from "../models/RegisterModel";
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({providedIn: "root"})
export class AuthService {
    helper = new JwtHelperService();

    currentUser = {
        username: null,
        email: null,
        role: null,
        jobtitle: null,
      };

    constructor(private http: HttpClient) {
        
    }
    register(model: RegisterModel) : Observable<any>{ 
        return this.http.post<any>('https://localhost:7065/api/User/Register', model);
    }

    login(model: LoginModel) : Observable<any> {
        return this.http.post('https://localhost:7065/api/User/Authenticate', model)
    }   
  IsloggedIn(): boolean {
    const token = localStorage.getItem('token');
    return !this.helper.isTokenExpired(token?.toString());
  }

  logout() {
    this.currentUser = {
      username: null,
      email: null,
      role: null,
      jobtitle: null,
    };
    localStorage.removeItem('token');
    localStorage.removeItem("fullname");
    localStorage.removeItem("id");
  }
}
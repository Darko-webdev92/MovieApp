import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(private router: Router) {}

    intercept(request: HttpRequest<unknown>, next: HttpHandler) : Observable<HttpEvent<unknown>> {
        
        let clonedRequest = request.clone();

        let url = this.router.url;

        if (!(url === "/Login" || url === "/Register")) {
            let token = localStorage.getItem("token");

            if (token) {
                clonedRequest = request.clone({
                    headers: request.headers.set('Authorization', `Bearer ${token}`)
                })
            }
        }

        return next.handle(clonedRequest)
    }

}
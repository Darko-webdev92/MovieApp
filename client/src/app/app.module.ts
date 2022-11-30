import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
// import { ReactiveFormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MoviesService } from './services/movies.service';
import { RouterModule, Routes } from '@angular/router';
import { MovieComponent } from './movie/movie.component';
import { NavbarComponent } from './navbar/navbar.component';
import { MoviesComponent } from './movies/movies.component';
import { HomeComponent } from './home/home.component';
import { UserComponent } from './user/user.component';
import { RegisterComponent } from './register/register.component';
import { AuthService } from './services/auth.service';
import { LoginComponent } from './login/login.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { NewMovieComponent } from './new-movie/new-movie.component';
import { AuthGuard } from './guards/AuthGuard';
import { MoviesByUserComponent } from './movies-by-user/movies-by-user.component';
import { MoviesByGenreComponent } from './movies-by-genre/movies-by-genre.component';


const routes: Routes = [
  {path: '', component: HomeComponent },
  {path: 'Home', component: HomeComponent},
  {path: 'Movies', component: MoviesComponent,  canActivate: [ AuthGuard ] },
  {path: 'Movies/Movie/:id', component: MovieComponent, canActivate: [ AuthGuard ] },
  {path: 'register', component: RegisterComponent },
  {path: 'login', component: LoginComponent },
  {path: 'newMovie', component: NewMovieComponent ,  canActivate: [ AuthGuard ] },
  {path: 'moviesByUser', component: MoviesByUserComponent,  canActivate: [ AuthGuard ]},
  {path: 'moviesByGenre', component: MoviesByGenreComponent,  canActivate: [ AuthGuard ]}
  
]
@NgModule({
  declarations: [
    AppComponent,
    MovieComponent,
    NavbarComponent,
    MoviesComponent,
    HomeComponent,
    UserComponent,
    RegisterComponent,
    LoginComponent,
    NewMovieComponent,
    MoviesByUserComponent,
    MoviesByGenreComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [MoviesService, AuthService,{
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }

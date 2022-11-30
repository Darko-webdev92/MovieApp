import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MoviesService } from './services/movies.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [MoviesService]
})
export class AppComponent implements OnInit {
  title = 'client';
  movieList: any; 
  constructor(public movieService: MoviesService ) { }
  ngOnInit(): void {

  }

  apiCall(){
    console.log("from the api call method")
    console.log(this.movieList);
  }
}

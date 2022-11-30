import { Component, OnInit } from '@angular/core';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css'],
  providers: [MoviesService]
})
export class MoviesComponent implements OnInit {
  movieList: any; 
  constructor(public movieService: MoviesService ) {
console.log("hello")

   }
  ngOnInit(): void {
    let token = localStorage.getItem("token");

   this.movieService.getMovies().subscribe( data =>{
    this.movieList = data;
    console.log(data)
    console.log(this.movieList);
    });

  }

}

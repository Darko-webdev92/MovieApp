import { Component, OnInit } from '@angular/core';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-movies-by-user',
  templateUrl: './movies-by-user.component.html',
  styleUrls: ['./movies-by-user.component.css']
})
export class MoviesByUserComponent implements OnInit {
  movieList: any; 
  constructor(private movieService: MoviesService ) { }

  ngOnInit(): void {
    this.movieService.getByUser().subscribe( data =>{
      this.movieList = data;
      console.log(data)
      console.log(this.movieList);
      })
  }

}

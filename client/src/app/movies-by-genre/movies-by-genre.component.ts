import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-movies-by-genre',
  templateUrl: './movies-by-genre.component.html',
  styleUrls: ['./movies-by-genre.component.css'],
  providers: [MoviesService]
})
export class MoviesByGenreComponent implements OnInit {
  genreOptions: string[] = ['Action', 'Comedy', "Mystery", "Thriller"];
  nrSelect = 47
  MovieByGenre = new FormGroup({
    Genre: new FormControl(),
  })

  movieList: any; 
  constructor(private movieService: MoviesService ) { }

  ngOnInit(): void  {
  }
  genreChange(value){
    // console.log(value);
    // console.log(this.MovieByGenre.value.Genre.value);
    // console.log(Number(this.MovieByGenre.value.Genre.value.toString().charAt(0)));

this.movieService.getByGenre(Number(this.MovieByGenre.value.Genre.value.toString().charAt(0))).subscribe( data =>{
  this.movieList = data;
  console.log(data)
  })
  }
}

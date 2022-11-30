import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { MovieModel } from '../models/MovieModel';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-new-movie',
  templateUrl: './new-movie.component.html',
  styleUrls: ['./new-movie.component.css'],
  providers: [MoviesService]
})
export class NewMovieComponent implements OnInit {
  genreOptions: string[] = ['Action', 'Comedy', "Mystery", "Thriller"];
  
  createMovie = new FormGroup({
    // Id: new FormControl(),
    Title: new FormControl(),
    Year: new FormControl(),
    Description: new FormControl(),
    Genre: new FormControl(),
  })

  constructor(private router: Router, private noteService: MoviesService) { }


  ngOnInit(): void {
  }

  genreChange(value) {
    console.log(value);
    console.log(this.createMovie.value.Genre.value);
    console.log(Number(this.createMovie.value.Genre.value.toString().charAt(0)));
  }
  OnSubmit(){ 
    let model = new MovieModel(this.createMovie.value.Title, this.createMovie.value.Year, this.createMovie.value.Description, Number(this.createMovie.value.Genre.value.toString().charAt(0)));
    console.log(model);
    this.noteService.addNewMovie(model).subscribe({
      error: err => console.warn(err.error),
      complete: () => {
        this.router.navigate(["/Movies"])
      }
    })
  }
}

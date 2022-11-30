import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css'],
})
export class MovieComponent implements OnInit {

  movie;
  movieId; 

  constructor(private activatedRoute: ActivatedRoute, private movieService: MoviesService) { }

  ngOnInit(): void {
    this.movieId = this.activatedRoute.snapshot.paramMap.get('id');
    // this.movie = this.movieService.getMovieById(this.movieId);
    this.movie = this.movieService.getMovieById(this.movieId).subscribe(data =>{
      this.movie = data;
    });

    console.log(this.movie);
  }

}

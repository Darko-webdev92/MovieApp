import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";


@Injectable({providedIn: "root"})
export class MoviesService{

    constructor(private http: HttpClient) {
        
    }
    getMovies(): Observable<any>{
        return this.http.get('https://localhost:7065/api/Movie/Movies');
    }

    getMovieById(id) : Observable<any>{
        return this.http.get('https://localhost:7065/api/Movie/MovieById/' + id);
    }

    addNewMovie(model) : Observable<any>{
        return this.http.post('https://localhost:7065/api/Movie/CreateMovie', model);

    }

    getByUser(){
        return this.http.get(' https://localhost:7065/api/Movie/GetAllByUser');
    }

    getByGenre(genre){
        return this.http.get('https://localhost:7065/api/Movie/MovieByGenre/' + genre);

    }

}
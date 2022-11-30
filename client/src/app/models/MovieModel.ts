export class MovieModel{
    // Id: number
    Title: string
    Year: number
    Description: string
    Genre: number

    constructor(title:string, year: number, description:string, genre:number){
        this.Title = title;
        this.Year = year;
        this.Description = description;
        this.Genre = genre;
        // this.Id = id;
    }
}
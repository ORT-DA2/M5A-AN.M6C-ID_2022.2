import { Component, OnInit } from '@angular/core';
import { MoviesService } from '../../services/movies.service';
import { Movie } from '../../models/movie';
import { Router } from '@angular/router';
import { catchError, filter, of, take } from 'rxjs';
import { IDeleteResponse } from 'src/app/interfaces/delete-response.interface';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent implements OnInit {

  public filterValue: string = '';
  public movies: Movie[] = [];

  constructor(
    private _moviesService: MoviesService,
    private _router: Router,
  ) { }

  public ngOnInit(): void {
    // cuando inicia el componente llamo al servicio para obtener las películas
    this._moviesService.getMovies().pipe(
      take(1),
      catchError((err) => {
        console.log({err});
        return of(err);
      }),
    )
    .subscribe(
      (movies: Movie[]) => {
        this.movies = movies;
      });
  }

  public navigateToAddMovie(): void {
    console.log('going to navigate to /movies/new');
    this._router.navigateByUrl('/movies/new');
  }

  public navigateToEditMovie(movie: Movie): void {
    this._router.navigateByUrl(`/movies/${movie.id}`);
  }

  public deleteMovie(movieToDelete: Movie): void {
    // voy a borrar la película
    this._moviesService.deleteMovie(movieToDelete?.id).pipe(
      take(1),
      catchError((err) => {
        console.log({err});
        return of(err);
      }),
      filter((response: IDeleteResponse) => response.success === true),
    ).subscribe((response: IDeleteResponse) => {
      this._moviesService.getMovies()
      .pipe(
        take(1),
        catchError((err) => {
          console.log({err});
          return of(err);
        }),
      ).subscribe((movies: Movie[] | undefined) => {
        this.setMovies(movies);
      });
    });
  }

  private setMovies = (movies: Movie[] | undefined) => {
    if(!movies) this.movies = [];
    else this.movies = movies;
  };
}

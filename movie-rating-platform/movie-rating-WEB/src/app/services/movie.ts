import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

export interface Actor {
  actorId: number;
  firstName: string;
  lastName: string;
  dateOfBirth: string;
}

export interface MovieRating {
  movieRatingId: number;
  rating: number;
  ratedAt: string;
  movieId: number;
}

export interface Movie {
  movieId: number;
  title: string;
  coverImage: string;
  shortDescription?: string;
  releaseDate: string;
  movieType: number;
  averageRating?: number;
  actors: Actor[];
  movieRatings: MovieRating[];
}

export interface MovieApiResponse {
  count: number;
  resultList: Movie[];
}

@Injectable({
  providedIn: 'root'
})
export class MoviesService {
  private baseUrl = 'http://localhost:5127/api/Movie';

  constructor(private http: HttpClient) {}

  getMovies(
    movieType: number = 0,
    page: number = 1,
    pageSize: number = 10,
    orderBy: string = 'AverageRating',
    sortDirection: string = 'Desc',
    searchKeyword: string = ''
  ): Observable<MovieApiResponse> {
    const params = new URLSearchParams({
      MovieTypeSearch: movieType.toString(),
      Page: page.toString(),
      PageSize: pageSize.toString(),
      OrderBy: orderBy,
      SortDirection: sortDirection
    });

    if (searchKeyword && searchKeyword.trim().length >= 2) {
      params.set('SearchKeyWord', searchKeyword.trim());
      // Opcionalno možeš override-ati paging ako želiš:
      // params.set('Page', '1');
      // params.set('PageSize', '100');
    }

    const url = `${this.baseUrl}?${params.toString()}`;
    return this.http.get<MovieApiResponse>(url);
  }

  getTopMovies(): Observable<Movie[]> {
    return this.getMovies(0, 1, 10, 'AverageRating', 'Desc')
      .pipe(map(response => response.resultList));
  }

  getMovieById(id: number): Observable<Movie> {
    return this.http.get<Movie>(`${this.baseUrl}/${id}`);
  }
}

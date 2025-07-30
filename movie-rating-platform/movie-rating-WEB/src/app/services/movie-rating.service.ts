import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

interface MovieRatingRequest {
  rating: number;
  movieId: number;
}

@Injectable({
  providedIn: 'root'
})
export class MovieRatingService {
  private apiUrl = `${environment.apiBaseUrl}/api/MovieRating`;

  constructor(private http: HttpClient) {}

  submitRating(movieId: number, rating: number): Observable<void> {
    const payload: MovieRatingRequest = {
      movieId,
      rating
    };
    return this.http.post<void>(this.apiUrl, payload);
  }
}

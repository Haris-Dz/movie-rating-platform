import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { MoviesService, Movie, MovieApiResponse } from '../../services/movie';
import { MovieRatingService } from '../../services/movie-rating.service';

import { SearchBar } from '../search-bar/search-bar';
import { ToggleType } from "../toggle-type/toggle-type";
import { RatingDialog } from '../rating-dialog/rating-dialog';

import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'movies-list',
  standalone: true,
  imports: [CommonModule, RouterModule, SearchBar, ToggleType, RatingDialog],
  templateUrl: './movies-list.html',
  styleUrls: ['./movies-list.css']
})
export class MoviesList implements OnInit {
  baseUrl = environment.apiBaseUrl;
  movies: Movie[] = [];
  loading = true;
  totalCount = 0;
  currentType = 0;
  currentPage = 1;
  pageSize = 10;
  successMessage: string | null = null;
  errorMessage: string | null = null;

  searchQuery = '';
  private searchSubject = new Subject<string>();

  @ViewChild(RatingDialog, { static: false }) ratingDialog!: RatingDialog;

  showRatingDialog = false;
  selectedMovie: Movie | null = null;

  constructor(
    private moviesService: MoviesService,
    private movieRatingService: MovieRatingService
  ) {}

  ngOnInit() {
    this.searchSubject.pipe(
      debounceTime(500)
    ).subscribe(query => {
      this.searchQuery = query;
      this.currentPage = 1;
      this.pageSize = 10;
      this.loadMovies();
    });

    this.loadMovies();
  }

  loadMovies() {
    this.loading = true;
    const searchActive = this.searchQuery.length >= 2;

    this.moviesService.getMovies(
      this.currentType,
      searchActive ? 1 : this.currentPage,
      searchActive ? 100 : this.pageSize,
      'AverageRating',
      'Desc',
      searchActive ? this.searchQuery : ''
    ).subscribe({
      next: (response: MovieApiResponse) => {
        this.movies = response.resultList;
        this.totalCount = response.count;
        this.loading = false;
      },
      error: () => {
        this.loading = false;
      }
    });
  }

  onSearch(query: string) {
    this.searchSubject.next(query);
  }

  onToggleChange(selectedType: number) {
    console.log('Selected toggle:', selectedType);
    this.currentType = selectedType;
    this.currentPage = 1;
    this.pageSize = 10;
    this.loadMovies();
  }

  showMore() {
    if (this.searchQuery.length >= 2) return;
    const scrollPosition = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop || 0;
    this.pageSize += 10;
    this.loadMovies();
    setTimeout(() => {
      window.scrollTo({ top: scrollPosition, behavior: 'smooth' });
    }, 55);
  }

  showLess() {
    if (this.searchQuery.length >= 2) return;
    if (this.pageSize > 10) {
      const scrollPosition = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop || 0;
      this.pageSize -= 10;
      this.loadMovies();
      setTimeout(() => {
        window.scrollTo({ top: scrollPosition, behavior: 'smooth' });
      }, 55);
    }
  }

  getStarFill(rating: number | undefined, star: number): number {
    if (!rating) return 0;
    const diff = rating - (star - 1);
    if (diff >= 1) return 100;
    if (diff <= 0) return 0;
    return diff * 100;
  }

  openRatingDialog(movie: Movie) {
    this.selectedMovie = movie;

    if (this.ratingDialog) {
      this.ratingDialog.reset();
    }

    this.showRatingDialog = true;
  }

  submitRating(rating: number) {
    if (!this.selectedMovie) return;

    if (rating < 1 || rating > 5) {
      this.errorMessage = 'Please select a rating between 1 and 5 stars.';
      setTimeout(() => this.errorMessage = null, 3000);
      return;
    }

    this.movieRatingService.submitRating(this.selectedMovie.movieId, rating).subscribe({
      next: () => {
        this.successMessage = `Successfully left rating for "${this.selectedMovie!.title}"!`;
        this.showRatingDialog = false;
        this.selectedMovie = null;
        this.loadMovies();

        setTimeout(() => this.successMessage = null, 3000);
      },
      error: (err) => {
        console.error('Failed to submit rating', err);
        alert('Failed to submit rating!');
      }
    });
  }

  cancelRating() {
    this.showRatingDialog = false;
    this.selectedMovie = null;
  }
}

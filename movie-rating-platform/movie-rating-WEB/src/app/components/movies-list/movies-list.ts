import { Component, OnInit } from '@angular/core';
import { MoviesService, Movie, MovieApiResponse } from '../../services/movie';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SearchBar } from '../search-bar/search-bar';
import { ToggleType } from "../toggle-type/toggle-type";

@Component({
  selector: 'movies-list',
  standalone: true,
  imports: [CommonModule, RouterModule, SearchBar, ToggleType],
  templateUrl: './movies-list.html',
  styleUrls: ['./movies-list.css']
})
export class MoviesList implements OnInit {
  movies: Movie[] = [];
  loading = true;
  totalCount = 0;
  currentType = 0;   // 0 = Movies, 1 = TV Shows
  currentPage = 1;
  pageSize = 10;
  searchQuery = '';

  constructor(private moviesService: MoviesService) {}

  ngOnInit() {
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
  this.searchQuery = query;
  this.currentPage = 1;
  this.pageSize = 10;
  this.loadMovies();
}


  onToggleChange(selectedType: number) {
    console.log('Selected toggle:', selectedType);
    this.currentType = selectedType;
    this.currentPage = 1;
    this.pageSize = 10;
    this.loadMovies();
  }

  showMore() {
    if (this.searchQuery.length >= 2) {
      return;
    }
    const scrollPosition = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop || 0;
    this.pageSize += 10;
    this.loadMovies();
    setTimeout(() => {
      window.scrollTo({ top: scrollPosition, behavior: 'smooth' });
    }, 55);
  }

  showLess() {
    if (this.searchQuery.length >= 2) {
      return;
    }
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
}

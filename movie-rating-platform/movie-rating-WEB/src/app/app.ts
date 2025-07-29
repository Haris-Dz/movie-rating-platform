import { Component } from '@angular/core';
import { MoviesList } from './components/movies-list/movies-list';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class AppComponent {}

export const routes = [
  { path: '', component: MoviesList },
];

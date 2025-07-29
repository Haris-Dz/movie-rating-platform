import { Component, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'search-bar',
  standalone: true,
  templateUrl: './search-bar.html',
  styleUrls: ['./search-bar.css'],
  imports: [FormsModule],
})
export class SearchBar {
  query = '';
  @Output() search = new EventEmitter<string>();

  onInputChange() {
    if (this.query.trim().length >= 2) {
      this.search.emit(this.query.trim());
    } else {
      this.search.emit(''); // možeš resetovati search
    }
  }
}

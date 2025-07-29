import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'toggle-type',
  standalone: true,
  templateUrl: './toggle-type.html',
  styleUrls: ['./toggle-type.css']
})
export class ToggleType {
  selected = 0;

  @Output() toggleChange = new EventEmitter<number>();

  selectToggle(value: number) {
    if (this.selected !== value) {
      this.selected = value;
      this.toggleChange.emit(this.selected);
    }
  }
}

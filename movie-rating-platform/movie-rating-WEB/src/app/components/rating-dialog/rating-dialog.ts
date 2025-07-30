import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-rating-dialog',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './rating-dialog.html',
  styleUrls: ['./rating-dialog.css']
})
export class RatingDialog {
    @Input() movieTitle!: string;
  @Input() visible: boolean = false;
  @Output() confirmed = new EventEmitter<number>();
  @Output() cancelled = new EventEmitter<void>();

  selectedRating = 0;

  setRating(value: number) {
    this.selectedRating = value;
  }

  confirm() {
    this.confirmed.emit(this.selectedRating);
  }
  reset() {
    this.selectedRating = 0;
  }

  cancel() {
    this.cancelled.emit();
  }
 }

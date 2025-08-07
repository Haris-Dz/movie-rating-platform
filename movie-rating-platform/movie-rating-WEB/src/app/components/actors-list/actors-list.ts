import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Actor, ActorService } from '../../services/actor.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-actor',
  standalone: true,
  templateUrl: './actors-list.html',
  styleUrls: ['./actors-list.css'],
  imports: [CommonModule]
})
export class ActorComponent implements OnInit {
  actors: Actor[] = [];
  errorMessage: string | null = null;
  loading = false;

  @Output() closed = new EventEmitter<void>();  // <-- dodaj ovo

  constructor(private actorService: ActorService) {}

  ngOnInit(): void {
    this.loadActors();
  }

  loadActors() {
    this.loading = true;
    this.errorMessage = null;

    this.actorService.getActors().subscribe({
      next: (res) => {
        this.actors = res.resultList;
        this.loading = false;
      },
      error: (err) => {
        this.loading = false;
        if (err.status === 401) {
          this.errorMessage = 'Unauthorized';
        } else {
          this.errorMessage = 'Failed to load actors.';
        }
      }
    });
  }

  closeAlert() {
    this.errorMessage = null;
    this.actors = [];
    this.loading = false;
    this.closed.emit();  // <-- emituj event roditelju
  }
}

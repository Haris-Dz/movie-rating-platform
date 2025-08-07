import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

export interface Actor {
  actorId: number;
  firstName: string;
  lastName: string;
  dateOfBirth: string; // možeš parsirati u Date ako trebaš
}

export interface ActorApiResponse {
  count: number;
  resultList: Actor[];
}

@Injectable({
  providedIn: 'root'
})
export class ActorService {
  private apiUrl = `${environment.apiBaseUrl}/api/Actor`;
  constructor(private http: HttpClient) {}

  getActors(): Observable<ActorApiResponse> {
    return this.http.get<ActorApiResponse>(this.apiUrl);
  }
}

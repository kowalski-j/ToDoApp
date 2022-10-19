import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Agenda } from '../models/agenda';


@Injectable({
  providedIn: 'root'
})
export class AgendaService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public getAgenda() : Observable<Agenda[]> {
    return this.http.get<Agenda[]>(`${this.baseUrl}/Agenda`);
  }

  public updateAgenda(agenda?: Agenda) : Observable<Agenda[]> {
    return this.http.post<Agenda[]>(`${this.baseUrl}/Agenda/updateList`, agenda);
  }

  public createAgenda(agenda?: Agenda) : Observable<Agenda[]> {
    console.log(agenda)
    return this.http.post<Agenda[]>(`${this.baseUrl}/Agenda/createList`, agenda);
  }

  public deleteAgenda(agenda?: Agenda) : Observable<Agenda[]> {
    return this.http.delete<Agenda[]>(`${this.baseUrl}/Agenda/${agenda?.id}`);
  }
}

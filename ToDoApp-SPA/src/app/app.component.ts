import { Component } from '@angular/core';
import { Agenda } from './models/agenda';
import { AgendaService } from './services/agenda.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ToDoApp-SPA';
  agendas: Agenda[] = [];
  agendaToEdit?: Agenda;

  constructor(private agendaService: AgendaService) {}

  ngOnInit(): void {
    this.agendaService.getAgenda().subscribe((result: Agenda[]) => (this.agendas = result));
  }

  updateAgendaList(agendas: Agenda[]){
    this.agendas = agendas;
  }

  initNewAgenda(){
    this.agendaToEdit = new Agenda()
  }

  editAgenda(agenda: Agenda){
    this.agendaToEdit = agenda;
  }
}

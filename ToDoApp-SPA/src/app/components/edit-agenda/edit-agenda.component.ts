import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Agenda } from 'src/app/models/agenda';
import { AgendaService } from 'src/app/services/agenda.service';

@Component({
  selector: 'app-edit-agenda',
  templateUrl: './edit-agenda.component.html',
  styleUrls: ['./edit-agenda.component.css']
})
export class EditAgendaComponent implements OnInit {
@Input() agenda? : Agenda;
@Output() agendaUpdated = new EventEmitter<Agenda[]>();

  constructor(private agendaService: AgendaService) { }

  ngOnInit(): void {
  }

  updateAgenda(agenda?: Agenda){
    this.agendaService
    .updateAgenda(agenda)
    .subscribe((agendas: Agenda[]) => this.agendaUpdated.emit(agendas));  

  }

  deleteAgenda(agenda?: Agenda){
    this.agendaService
    .deleteAgenda(agenda)
    .subscribe((agendas: Agenda[]) => this.agendaUpdated.emit(agendas));  
  }
  
  createAgenda(agenda?: Agenda){
    this.agendaService
    .createAgenda(agenda)    
    .subscribe((agendas: Agenda[]) => this.agendaUpdated.emit(agendas));  

 }


}

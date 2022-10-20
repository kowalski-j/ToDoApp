import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Agenda } from 'src/app/models/agenda';
import { AgendaService } from 'src/app/services/agenda.service';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-edit-agenda',
  templateUrl: './edit-agenda.component.html',
  styleUrls: ['./edit-agenda.component.css']
})
export class EditAgendaComponent implements OnInit {
@Input() agenda? : Agenda;
@Output() agendaUpdated = new EventEmitter<Agenda[]>();

  constructor(private agendaService: AgendaService, private alertify: AlertifyService) { }

  ngOnInit(): void {
  }

  updateAgenda(agenda?: Agenda){
    this.agendaService
    .updateAgenda(agenda)
    .subscribe(() => {
      window.location.reload();
    });
 }

  deleteAgenda(agenda?: Agenda){
    this.agendaService
    .deleteAgenda(agenda)
    .subscribe(() => {
      window.location.reload();
    });
 }
  
  createAgenda(agenda?: Agenda){
    this.agendaService
    .createAgenda(agenda)    
    .subscribe(() => {
      window.location.reload();
    });
 }


}

import { Component, OnInit } from '@angular/core';
import { ServicioService } from '../services/servicio.service';

@Component({
  selector: 'app-primero',
  templateUrl: './primero.component.html',
  styleUrls: ['./primero.component.css'],
})
export class PrimeroComponent {
  names: string[];
  condition: boolean;
  inputValue: string;
  filter: string;
  textEmited: string;
  constructor(private service: ServicioService) {
    this.names = ['Nicolas', 'Juan', 'Valentina', 'Valeria'];
    this.condition = true;
    this.inputValue = '';
    this.names = service.getNames();
  }

  clickList(name) {
    alert('Hola ' + name);
  }

  focus($event) {
    alert('Enfocaste el input...');
  }

  modifyEmit(text: string) {
    this.textEmited = text;
  }
}

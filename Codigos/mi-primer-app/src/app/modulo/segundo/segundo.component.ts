import { Component, EventEmitter, Output, Input } from '@angular/core';

@Component({
  selector: 'app-segundo',
  templateUrl: './segundo.component.html',
  styleUrls: ['./segundo.component.css'],
})
export class SegundoComponent {

  @Output() textSent = new EventEmitter<string>();
  @Input() text: string;
  textToSend: string;
  constructor() {
    this.text = '';
    this.textToSend = '';
  }
  send($event){
    this.textSent.emit(this.textToSend);
  }
}

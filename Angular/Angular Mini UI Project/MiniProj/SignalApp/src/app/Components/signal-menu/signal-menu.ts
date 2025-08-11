import { Component } from '@angular/core';
import { Output, EventEmitter } from '@angular/core';
@Component({
  selector: 'app-signal-menu',
  standalone: false,
  templateUrl: './signal-menu.html',
  styleUrl: './signal-menu.css'
})
export class SignalMenu {

  @Output() signalTypeChange = new EventEmitter<string>();

  changeSignalType(signalType: string) {
    console.log('Button Clicked', signalType);
    this.signalTypeChange.emit(signalType);
    this.onSignalChange(signalType);
  }

  message = '';

  onSignalChange(signalType: string) {
    console.log('Signal Change', signalType);
    switch(signalType) {
      case 'red':
        this.message = 'Stop';
        break;
      case 'yellow':
        this.message = 'Slow down';
        break;
      case 'green':
        this.message = 'Runaway';
        break;
      default:
        this.message = '';
    }
  }

}

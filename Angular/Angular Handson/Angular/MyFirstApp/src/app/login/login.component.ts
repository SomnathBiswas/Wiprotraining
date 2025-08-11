import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
 
  @Input() caption: string = 'Login';
  @Output() login = new EventEmitter<string>();
  img = 'https://cdn-icons-png.flaticon.com/512/149/149071.png';
  username: string = '';
  password: string = '';
  col: string = 'col-12';
  
  onLogin() {
    console.log("username:", this.username, "password:", this.password,);
    this.login.emit(this.username);
  }

}

import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'My Frontend App';
  myhobby:any = [{name:'Read, fav:'}]
  login(caption: string) {
    this.title = caption
  }
}

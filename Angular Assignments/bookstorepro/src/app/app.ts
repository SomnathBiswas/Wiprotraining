import { Component, signal } from '@angular/core';
import { Books } from './components/books/books';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('bookstorepro');
}

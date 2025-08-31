import { Component, Input } from '@angular/core';
import { Book } from '../../model/book.model'; 

@Component({
  selector: 'app-book-item',
  standalone: false,
  templateUrl: './book-item.html',
  styleUrl: './book-item.css'
})
export class BookItem {

 @Input() book!: Book;
}
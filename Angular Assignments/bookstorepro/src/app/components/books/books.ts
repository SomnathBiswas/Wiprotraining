import { Component, Input } from '@angular/core';
import { Book } from '../../model/book.model';
import { OnInit, OnDestroy } from '@angular/core';
import { Data } from '../../service/data';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-books',
  standalone: false,
  templateUrl: './books.html',
  styleUrl: './books.css'
})
export class Books implements OnInit, OnDestroy {
   books$!: Observable<Book[]>;         
  manualBooks: Book[] = [];            
  private sub?: Subscription;

  constructor(private data: Data) {}

  ngOnInit(): void {
    this.books$ = this.data.getBooks();
    this.sub = this.data.getBooks().subscribe({
      next: (books) => (this.manualBooks = books),
      error: (err) => console.error('Error loading books (manual):', err)
    });
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }
}

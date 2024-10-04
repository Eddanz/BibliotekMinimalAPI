import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Book } from '../Models/book';
import { HttpClientModule } from '@angular/common/http';
import { BookService } from '../Service/book.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-books',
  standalone: true,
  imports: [RouterOutlet, FormsModule, CommonModule, HttpClientModule],
  providers: [BookService],
  templateUrl: './books.component.html',
  styleUrl: './books.component.css'
})
export class BooksComponent implements OnInit {
  books: Book[] = [];

  constructor(private bookService: BookService, private router: Router) { }

  ngOnInit(): void {
    this.getBookList();
  }

  getBookList(): void {
    this.bookService.getBookList().subscribe({
      next: (data: Book[]) => {
        this.books = data;
      },
      error: (error: any) => {
        console.error('Error fetching books:', error);
      }
    });
  }

  onBookClick(bookId: string): void {
    this.router.navigate(['/book', bookId]);
  }
}

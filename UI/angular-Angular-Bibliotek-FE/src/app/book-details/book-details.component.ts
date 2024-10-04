// src/app/book-details/book-details.component.ts
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { BookService } from '../Service/book.service';
import { Book } from '../Models/book';

@Component({
  selector: 'app-book-details',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  providers: [BookService],
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css']
})
export class BookDetailsComponent implements OnInit {
  book: Book | undefined;

  constructor(private route: ActivatedRoute, private bookService: BookService, private router: Router) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const bookId = params.get('id');
      console.log('Book ID from route:', bookId); // Debugging statement
      if (bookId) {
        this.getBookById(bookId);
      }
    });
  }

  getBookById(id: string): void {
    this.bookService.getBookById(id).subscribe({
      next: (data: Book) => {
        console.log('Fetched book details:', data); // Debugging statement
        this.book = data;
      },
      error: (error: any) => {
        console.error('Error fetching book details:', error);
      }
    });
  }

  goBack(): void {
    this.router.navigate(['/book']);
  }

  updateBook(): void {
    if (this.book) {
      this.router.navigate(['/update-book', this.book.id]);
    }
  }

  deleteBook(): void {
    if (this.book && confirm('Are you sure you want to delete this book?')) {
      this.bookService.deleteBook(this.book.id).subscribe({
        next: () => {
          alert('Book deleted successfully');
          this.router.navigate(['/book']);
        },
        error: (error: any) => {
          console.error('Error deleting book:', error);
          alert('Failed to delete the book');
        }
      });
    }
  }
}
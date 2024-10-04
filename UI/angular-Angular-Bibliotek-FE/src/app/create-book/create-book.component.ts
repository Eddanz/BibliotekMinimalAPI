import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BookService } from '../Service/book.service';
import { Book } from '../Models/book';

@Component({
  selector: 'app-create-book',
  templateUrl: './create-book.component.html',
  styleUrls: ['./create-book.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class CreateBookComponent {
  book: Book = {
    id: '',
    title: '',
    author: '',
    genre: '',
    description: '',
    publishingYear: '',
    isAvailable: ''
  };

  constructor(
    private router: Router,
    private bookService: BookService
  ) {}

  onSubmit(): void {
    this.bookService.createBook(this.book).subscribe({
      next: () => {
        alert('Book created successfully');
        this.router.navigate(['/book']);
      },
      error: (error: any) => {
        console.error('Error creating book:', error);
        alert('Failed to create the book');
      }
    });
  }

  goBack(): void {
    this.router.navigate(['/book']);
  }
}

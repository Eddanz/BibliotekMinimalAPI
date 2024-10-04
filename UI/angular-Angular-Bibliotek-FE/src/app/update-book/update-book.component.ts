import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BookService } from '../Service/book.service';
import { Book } from '../Models/book';

@Component({
  selector: 'app-update-book',
  templateUrl: './update-book.component.html',
  styleUrls: ['./update-book.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class UpdateBookComponent implements OnInit {
  book: Book | undefined;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private bookService: BookService
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.getBookById(id);
    }
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

  onSubmit(): void {
    if (this.book) {
      this.bookService.updateBook(this.book.id, this.book).subscribe({
        next: () => {
          alert('Book updated successfully');
          this.router.navigate(['/book']);
        },
        error: (error: any) => {
          console.error('Error updating book:', error);
          alert('Failed to update the book');
        }
      });
    }
  }

  goBack(): void {
    this.router.navigate(['/book']);
  }
}

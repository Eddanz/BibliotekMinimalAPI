// app.component.ts
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BookService } from './Service/book.service';
import { Book } from './Models/book';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms'; // Import FormsModule

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone: true,
  imports: [RouterModule, FormsModule] // Import RouterModule if needed
})
export class AppComponent { 
  searchQuery: string = '';

  constructor(private router: Router, private bookService: BookService) {}

  onSearch(event: Event): void {
    event.preventDefault();
    if (this.searchQuery.trim()) {
      this.bookService.getBookList().subscribe({
        next: (books: Book[]) => {
          const matchedBook = books.find(book => book.title.toLowerCase().includes(this.searchQuery.toLowerCase()));
          if (matchedBook) {
            this.router.navigate(['/book', matchedBook.id]);
          } else {
            alert('No matching book found');
          }
        },
        error: (error: any) => {
          console.error('Error fetching book list:', error);
        }
      });
    }
  }
}

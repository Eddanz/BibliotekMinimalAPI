import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BooksComponent } from './books/books.component';
import { BookDetailsComponent } from './book-details/book-details.component';
import { CreateBookComponent } from './create-book/create-book.component';


export const routes: Routes = [
  { path: '', component: HomeComponent }, // Default route for homepage
  { path: 'book', component: BooksComponent }, // Route for books
  { path: 'book/:id', component: BookDetailsComponent }, // Route for book details
  { path: 'create-book', component: CreateBookComponent }, // Route for creating a book
  { path: 'update-book/:id', loadComponent: () => import('./update-book/update-book.component').then(m => m.UpdateBookComponent) }, // Route for updating book
  // Add more routes as needed
];

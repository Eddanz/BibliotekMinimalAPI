import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError, map } from "rxjs/operators";
import { Book } from "../Models/book";

interface ApiResponse<T> {
  isSuccess: boolean;
  result: T;
  statusCode: number;
  errorMessages: string[];
}

@Injectable({
  providedIn: 'root'
})
export class BookService {
  baseUrl = 'https://localhost:7165/api/book';

  constructor(private http: HttpClient) { }

  getBookList(): Observable<Book[]> {
    return this.http.get<ApiResponse<Book[]>>(this.baseUrl).pipe(
      map(response => {
        if (response.isSuccess) {
          return response.result;
        } else {
          throw new Error('API response indicates failure');
        }
      }),
      catchError(this.handleError)
    );
  }

  createBook(book: Book): Observable<Object> {
    return this.http.post(this.baseUrl, book).pipe(
      catchError(this.handleError)
    );
  }

  getBookById(id: string): Observable<Book> {
    return this.http.get<ApiResponse<Book>>(`${this.baseUrl}/${id}`).pipe(
      map(response => {
        console.log('API response:', response); // Debugging statement
        if (response.isSuccess) {
          const book = response.result;
          if (!book) {
            throw new Error('Book not found');
          }
          return book;
        } else {
          throw new Error('API response indicates failure');
        }
      }),
      catchError(this.handleError)
    );
  }

  updateBook(id: string, book: Book): Observable<Object> {
    return this.http.put(this.baseUrl, book).pipe(
      catchError(this.handleError)
    );
  }

  deleteBook(id: string): Observable<Object> {
    return this.http.delete(`${this.baseUrl}/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    console.error('An error occurred:', error.message);
    return throwError('Something went wrong; please try again later.');
  }
}

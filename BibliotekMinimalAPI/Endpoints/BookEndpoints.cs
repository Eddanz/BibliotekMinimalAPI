using AutoMapper;
using Azure;
using BibliotekMinimalAPI.Models;
using BibliotekMinimalAPI.Models.DTOs;
using BibliotekMinimalAPI.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BibliotekMinimalAPI.Endpoints
{
    public static class BookEndpoints
    {
        public static void ConfigurationBookEndpoints(this WebApplication app)
        {
            app.MapGet("/api/book", GetAllBooks)
                .WithName("GetBooks")
                .Produces<APIResponse>();

            app.MapGet("/api/book/{id:Guid}", GetBook)
                .WithName("GetBook")
                .Produces<APIResponse>();

            app.MapPost("/api/book", AddBook)
                .WithName("Addbook")
                .Accepts<BookCreateDTO>("application/json")
                .Produces(201).Produces(400);

            app.MapPut("/api/book", UpdateBook)
                .WithName("UpdateBook")
                .Accepts<BookUpdateDTO>("application/json")
                .Produces<BookUpdateDTO>(200).Produces(400);

            app.MapDelete("/api/book/{id:Guid}", DeleteBook)
                .WithName("DeleteBook");
        }

        private async static Task<IResult> GetAllBooks(IBookRepository _bookRepository)
        {
            APIResponse response = new APIResponse();

            response.Result = await _bookRepository.GetAllAsync();
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;

            return Results.Ok(response);
        }

        private async static Task<IResult> GetBook(IBookRepository _bookRepository, Guid id)
        {
            APIResponse response = new APIResponse();

            response.Result = await _bookRepository.GetAsync(id);
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;

            return Results.Ok(response);
        }

        private async static Task<IResult> AddBook(IBookRepository _bookRepository, IMapper _mapper, IValidator<BookCreateDTO> validator, BookCreateDTO bookCreateDTO)
        {
            APIResponse response = new APIResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest
            };

            var validatorResult = await validator.ValidateAsync(bookCreateDTO);
            if (!validatorResult.IsValid)
            {
                response.ErrorMessages = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Results.BadRequest(response);
            }

            var existingBook = await _bookRepository.GetAsync(bookCreateDTO.Title);
            if (existingBook != null)
            {
                response.ErrorMessages.Add("Book with this Title already exists");
                return Results.BadRequest(response);
            }

            Book book = _mapper.Map<Book>(bookCreateDTO);
            await _bookRepository.CreateAsync(book);
            await _bookRepository.SaveAsync();
            BookDTO bookDTO = _mapper.Map<BookDTO>(book);

            response.Result = bookDTO;
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.Created;

            return Results.Ok(response);
        }

        private async static Task<IResult> UpdateBook(IBookRepository _bookRepository, IMapper _mapper, IValidator<BookUpdateDTO> validator, BookUpdateDTO bookUpdateDTO)
        {
            APIResponse response = new APIResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest
            };

            var validatorResult = await validator.ValidateAsync(bookUpdateDTO);
            if (!validatorResult.IsValid)
            {
                response.ErrorMessages = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Results.BadRequest(response);
            }

            await _bookRepository.UpdateAsync(_mapper.Map<Book>(bookUpdateDTO));
            await _bookRepository.SaveAsync();

            response.Result = _mapper.Map<BookDTO>(await _bookRepository.GetAsync(bookUpdateDTO.Id));
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            return Results.Ok(response);
        }

        private async static Task<IResult> DeleteBook(IBookRepository _bookRepository, Guid id)
        {
            APIResponse response = new()
            {
                IsSuccess = false,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };

            Book bookToDelete = await _bookRepository.GetAsync(id);

            if (bookToDelete != null)
            {
                await _bookRepository.DeleteAsync(bookToDelete);
                await _bookRepository.SaveAsync();

                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.NoContent;
                return Results.Ok(response);
            }
            else
            {
                response.ErrorMessages.Add("Invalid ID");
                return Results.BadRequest(response);
            }
        }
    }
}

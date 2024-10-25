﻿using Library.Api.Models;
using Library.Api.Services.Contracts;
using Library.Data;
using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Api.Services
{
    public class BookService : IBookService
    {
        private LibraryDbContext context;
        public BookService(LibraryDbContext _context)
        {
            context = _context;
        }
        public void AddNewBook(BookDto book)
        {
            if (context.Books.FirstOrDefault(x => x.Header == book.Header) != null)
            {
                return;
            }

            Book newBook = new Book()
            {
                Header = book.Header,
                Description = book.Description,
                Pages = book.Pages,
                Rating = book.Rating,
                Author = book.Author
            };

            newBook.UserId = null;

            context.Books.Add(newBook);

            context.SaveChanges();
        }

        public JsonResult AllBooks(BookFilter filter)
        {
            var list = context
                .Books
                .Where(x => x.Pages >= filter.FromPages && x.Pages <= filter.ToPages
                && x.Header.Contains(filter.Header) && x.IsFree == filter.IsFree)
                .Select(x => new BookApiModel
                {
                    Header = x.Header,
                    Description = x.Description,
                    Pages = x.Pages
                })
                .ToList();

            var jsonResult = new JsonResult();

            jsonResult.BuildBooks(list, filter.Page);

            return jsonResult;
        }

        public string RemoveBookByName(string header)
        {
            var book = context.Books.FirstOrDefault(x => x.Header == header);
            if (book != null)
            {
                if (book.IsFree == false)
                {
                    return "This book is busy at now.";
                }
                context.Books.Remove(book);

                context.SaveChanges();

                return $"Book with header: {header} is removed from library.";
            }
            return "Book does't exist in library.";
        }

        public string TakeBookByName(string header, UserModel user)
        {
            var book = context.Books.FirstOrDefault(x => x.Header == header);
            if (book != null)
            {
                if (book.IsFree == false)
                {
                    return "This book is busy at now.";
                }

                var dbUser = context.Users.FirstOrDefault(x => x.Name == user.Username && x.Email == user.EmailAddress);

                if (context.Books.Where(x => x.UserId == dbUser.Id).Count() >= 3)
                {
                    return "You can't get more than 3 books at one time";
                }

                if (dbUser.Points <= 0)
                {
                    return "You don't have enought points.";
                }

                dbUser.Books.Add(book);

                book.IsFree = false;

                book.LastDateForGiveBack = DateTime.Now.AddDays(90);

                context.SaveChanges();

                return $"Book with header: {header} is added to your collection.";
            }
            return "You cannot get this book!";
        }

        public IEnumerable<BookWithReaderId> CheckBooks()
        {
            var list = context.Books.Where(x => x.IsFree == false && x.LastDateForGiveBack < DateTime.Now).ToList();

            if (list.Count() == 0)
            {
                return null;
            }

            foreach (var item in list)
            {
                item.Overdue = true;
            }

            context.SaveChanges();

            var booksWithOverdue = list.Select(x => new BookWithReaderId()
            {
                Header = x.Header,
                IsFree = x.IsFree,
                LastDateForGiveBack = x.LastDateForGiveBack,
                Overdue = x.Overdue,
                UserName = context.Users.FirstOrDefault(s => x.UserId == s.Id).Name
            });

            return booksWithOverdue;
        }

        public string GiveBackBookByName(string header, UserModel user)
        {
            var dbUser = context.Users.FirstOrDefault(x => x.Email == user.EmailAddress && x.Name == user.Username);

            if (dbUser != null)
            {
                var book = context.Books.FirstOrDefault(x => x.UserId == dbUser.Id && x.Header == header);

                if (book != null)
                {
                    if (book.Overdue == true)
                    {
                        dbUser.Points -= 3;
                    }
                    else
                    {
                        dbUser.Points += 1;
                    }

                    book.IsFree = true;
                    book.UserId = null;
                    book.Overdue = false;
                    book.LastDateForGiveBack = new DateTime();

                    context.SaveChanges();

                    return $"You successfully give back book with header: {header}";
                    //TODO: decrement user points if overdue is true
                }
                return "You don't have this book in your collection of books!";
            }
            return "You are not logged.";
        }
    }
}

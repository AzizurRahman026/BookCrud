﻿using System.Collections.Specialized;
using System.Reflection.Metadata.Ecma335;
using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Service
{
    public class BookService : IBookCountService
    {
        //private field...
        private static int totalBook;
        private readonly List<Book> _books;

        //constructor
        public BookService()
        {
            totalBook = 0;
            _books = new List<Book>();
        }

        public int addBook(AddBookRequest addBook)
        {
            int idx = _books.Count;
            for (int i = 0; i < _books.Count; ++i)
            {
                if (_books[i].bookID == addBook.bookID) idx = i;
            }

            if (idx < _books.Count)
            {
                _books[idx].numberOfBook += addBook.numberOfBook;
            }
            else
            {
                Book book = addBook.ToBook();
                _books.Add(book);
            }

            totalBook += addBook.numberOfBook;

            foreach (Book b in _books)
            {
                Console.WriteLine(
                    $"Book id: {b.bookID}\nBookName is: {b.bookName}\nBookAuthor id is: {b.bookAuthor}\nNumber of Book: {b.numberOfBook}");
            }

            Console.WriteLine($"Book Added Successfully.");
            return totalBook;
        }

        public int removeBook(removeBook info)
        {
            int idx = _books.Count, id = (int)info.id, cnt = (int)info.count;
            Console.WriteLine($"Id: {id} count: {cnt}");
            for (int i = 0; i < _books.Count; ++i)
            {
                if (_books[i].bookID == id) idx = i;
            }

            if (idx < _books.Count)
            {
                Console.WriteLine("Book removes successfully...");
                cnt = Math.Min(_books[idx].numberOfBook, cnt);
                _books[idx].numberOfBook -= cnt;
                totalBook -= cnt;
                if (totalBook <= 0)
                {
                    totalBook = 0;
                    _books.RemoveAt(idx);
                }
            }
            else
            {
                Console.WriteLine("Book removes not successfull...");
                cnt = 0;
            }
            return cnt;
        }

        public int currentBook()
        {
            // Console.WriteLine("Hello I am coming from interface class...");
            // return 1000;
            return totalBook;
        }

        /*
         
        public countryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            //Validation: countryAddRequest parameter can't be null
            if (countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            //Validation: CountryName can't be null
            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            //Validation: CountryName can't be duplicate
            if (_countries.Where(temp => temp.CountryName == countryAddRequest.CountryName).Count() > 0)
            {
                throw new ArgumentException("Given country name already exists");
            }



            // ---- alternate Implementation  -----
            //var countr = new country();
            //countr.CountryName = countryAddRequest.CountryName;
             
             
            //Convert object from CountryAddRequest to Country type
            Country country = countryAddRequest.ToCountry();

            //generate CountryID
            country.CountryID = Guid.NewGuid();

            //Add country object into _countries
            _countries.Add(country);

            return country.ToCountryResponse();
        }
         
         */
    }
}
using Entities;

namespace ServiceContracts.DTO
{
    public class AddBookRequest
    {
        public int bookID { get; set; }
        public string? bookName { get; set; }
        public string? bookAuthor { get; set; }
        public int numberOfBook { get; set; }

        /*public Country ToCountry()
        {
            return new Country()
            {
                CountryID = new Guid(),
                CountryName = CountryName
            };

            //return new Country() { CountryName = CountryName };
        }*/
        public Book ToBook()
        {
            return new Book()
            {
                bookID = bookID,
                bookName = bookName,
                bookAuthor = bookAuthor,
                numberOfBook = numberOfBook
            };
        }
    }
}
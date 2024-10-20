using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface IBookCountService
    {
        // countryResponse AddCountry(CountryAddRequest? countryAddRequest);
        int addBook(AddBookRequest book);
        int removeBook(int id, int count=0);
        int currentBook();
    }
}
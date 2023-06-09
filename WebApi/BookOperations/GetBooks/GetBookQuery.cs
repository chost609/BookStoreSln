using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DBOperations;
namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        public List<BooksViewModal> Handle()
        {
            var bookList=_dbContext.Books.OrderBy(x=>x.Id).ToList<Book>();
            List<BooksViewModal> vm = new List<BooksViewModal>();
            foreach (var book in bookList)
            {
                vm.Add(new BooksViewModal(){
                    Title=book.Title,
                    Genre=((GenreEnum)book.GenreId).ToString(),
                    PublishDate=book.PublishDate.Date.ToString("dd-MM-yyy"),
                    PageCount=book.PageCount
                });
            }   
            return vm; 
        }
    }

    public class BooksViewModal
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
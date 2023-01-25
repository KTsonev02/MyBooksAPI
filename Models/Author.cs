using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksAPI.Data.Models
{
    public class Author
    {
        [Name("authorId")]
        public int Id { get; set; }

        [Name("author")]
        public string FullName { get; set; }


        public List<Book_Author> Book_Authors { get; set; }
    }
}

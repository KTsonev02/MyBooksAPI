using CsvHelper.Configuration.Attributes;
using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksAPI.Data.Models
{
    public class Publisher
    {
        [CsvColumn (Name = "publisherId", FieldIndex = 23)]
        public int Id { get; set; }

        [CsvColumn(Name = "publisher", FieldIndex = 14)]
        public string Name { get; set; }


        public List<Book> Books { get; set; }
    }
}

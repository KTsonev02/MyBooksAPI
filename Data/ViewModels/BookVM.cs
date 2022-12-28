using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksAPI.Data.ViewModels
{
    public class BookVM
    {
        public string Title { get; set; }
        public string Discription { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public int? Rate { get; set; }
    }
}

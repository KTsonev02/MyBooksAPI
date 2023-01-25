using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooksAPI.Utility
{
    public class TemplateGenerator
    {
        private record Books(string Title, string Author, double Rating, string Genres);
        public static string GetHTMLString()
        {
            var books = new List<Books>
            {
                new Books ( "The Hunger Games", "Suzanne Collins", 4.33, "'Young Adult', 'Fiction', 'Dystopia', 'Fantasy'"),
                new Books ( "Harry Potter", "J.K. Rowling", 4.5, "'Classics', 'Fiction', 'Historical Fiction', 'School', 'Literature'"),
                new Books ( "To Kill a Mockingbird", "Harper Lee", 4.28, "'Classics', 'Fiction', 'Historical Fiction', 'School'"),
                new Books ( "Pride and Prejudice", "Jane Austen", 4.26, "'Classics', 'Fiction', 'Romance', 'Historical Fiction'"),
                new Books ( "Twilight", "Stephenie Meyer", 3.6, "'Young Adult', 'Fantasy', 'Romance', 'Vampires'")
            };
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is a list of the best books of the month</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Title</th>
                                        <th>Author</th>
                                        <th>Rating</th>
                                        <th>Genres</th>
                                    </tr>");
            foreach (var boo in books)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", boo.Title, boo.Author, boo.Rating, boo.Genres);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
    }
}

         
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MyBooksAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
﻿using CsvHelper;
using System.Globalization;
using System.IO;

namespace MyBooksAPI.Data
{
    public class AppDbInitializer
    {
        public static void SeedPublishers(AppDbContext context)
        {
            if (context.Publishers.Any())
            {
                return;
            }

            using var reader = new StreamReader("Books.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Read();
            csv.ReadHeader();

            while (csv.Read())
            {
                string publisherName = csv.GetField("publisher");

                if (string.IsNullOrEmpty(publisherName) || context.Publishers.Any(p => p.Name == publisherName))
                {
                    continue;
                }

                var publisher = new Publisher { Name = publisherName };
                context.Publishers.Add(publisher);
                context.SaveChanges();

            }
        }
        public static void SeedAuthors(AppDbContext context)
        {
            if (context.Authors.Any())
            {
               return;
            }

            using var reader = new StreamReader("Books.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Read();
            csv.ReadHeader();

            while (csv.Read())
            {
                string[] authorNames = csv.GetField("author").Split(",");
                foreach (string name in authorNames)
                {
                    if (string.IsNullOrEmpty(name) || context.Authors.Any(a => a.FullName == name))
                    {
                        continue;
                    }

                    var author = new Author { FullName = name };
                    context.Authors.Add(author);
                    context.SaveChanges();
                }
            }
        }
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st Book Title",
                        Description = "1st Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        DateAdded = DateTime.Now
                    },
                    new Book()
                    {
                        Title = "second Book Title",
                        Description = "second Book Description",
                        IsRead = false,
                        Rate = 4,
                        Genre = "Biography",
                        DateAdded = DateTime.Now
                    });


                    context.SaveChanges();
                }

            }
        }

        
    }

}
    


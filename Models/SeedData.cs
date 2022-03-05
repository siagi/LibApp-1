using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (!context.MembershipTypes.Any())
                {

                    context.MembershipTypes.AddRange(
                        new MembershipType
                        {
                            Id = 1,
                            SignUpFee = 0,
                            DurationInMonths = 0,
                            DiscountRate = 0,
                            Name = "Basic"
                        },
                        new MembershipType
                        {
                            Id = 2,
                            SignUpFee = 30,
                            DurationInMonths = 1,
                            DiscountRate = 10,
                            Name = "Standard"
                        },
                        new MembershipType
                        {
                            Id = 3,
                            SignUpFee = 90,
                            DurationInMonths = 3,
                            DiscountRate = 15,
                            Name = "Silver"
                        },
                        new MembershipType
                        {
                            Id = 4,
                            SignUpFee = 300,
                            DurationInMonths = 12,
                            DiscountRate = 20,
                            Name = "Gold"
                        });
                    context.SaveChanges();
                }

                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(
                        new Customer
                        {
                            
                            Name = "Pawel",
                            HasNewsletterSubscribed=false,
                            MembershipTypeId = 2,
                            Birthdate = new DateTime(1977,6,18)
                        },
                        new Customer
                        {
                            
                            Name = "Kasia",
                            HasNewsletterSubscribed = false,
                            MembershipTypeId = 3,
                            Birthdate = new DateTime(1988, 1, 26)
                        });
                    context.SaveChanges();

                }

                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book
                        {
                            
                            Name = "It Ends with Us",
                            AuthorName = "Hoover Colleen",
                            GenreId = 2,
                            DateAdded = new DateTime(2010, 10, 13),
                            ReleaseDate = new DateTime(2009, 5, 20),
                            NumberInStock = 20,
                            NumberAvailable = 10,
                        },
                        new Book
                        {
                            
                            Name = "Wojna w Kosmosie. Przewrót w geopolityce",
                            AuthorName = "Bartosiak Jacek",
                            GenreId = 2,
                            DateAdded = new DateTime(2022, 02, 15),
                            ReleaseDate = new DateTime(2022, 02, 01),
                            NumberInStock = 5,
                            NumberAvailable = 10,
                        });
                    context.SaveChanges();

                }
                else
                {
                    Console.WriteLine("Database already seeded");
                    return;

                }

            }
        }
    }
}
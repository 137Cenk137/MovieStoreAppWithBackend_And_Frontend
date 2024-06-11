using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace WebApi.DBoperitions;
public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MovieStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDBContext>>()))
        {
            // Check if data already exists
            

            // Create some genres
            var genres = new List<Genre>
            {
                new Genre { GenreName = "Action" },
                new Genre { GenreName = "Comedy" },
                new Genre { GenreName = "Drama" }
            };
            context.Genres.AddRange(genres);

            // Create some actors
            var actors = new List<Actor>
            {
                new Actor { Name = "Tom Hanks" },
                new Actor { Name = "Julia Roberts" }
            };
            context.Actors.AddRange(actors);
            
            // Create some movies and associate with genres and actors
            var movies = new List<Movie>
            {
                new Movie
                {
                    Name = "Big",
                    Price = 10,
                    PublishDate = new DateTime(1988, 6, 3),
                    Description = "A comedy about a boy who wishes to be big.",
                    Genre = genres[1], // Comedy
                    Director = new Director { Name = "Penny Marshall" },
                    Actors = new List<MovieActor>
                    {
                        new MovieActor { Actor = actors[0] } // Tom Hanks
                    }
                }
            };
            context.Movies.AddRange(movies);
            

            // Create some customers
            var customers = new List<Customer>
            {
                new Customer { Name = "John Doe" },
                new Customer { Name = "Jane Smith" }
            };
            context.Customers.AddRange(customers);
          

            // Create orders
            /*var orders = new List<Order>
            {
                new Order
                {
                    TotalPrice = 10.99,
                    Customer = customers[0],
                    Movies = new List<Movie> { movies[0] }
                }
            };
            context.Orders.AddRange(orders);*/

            // Save all changes to the database
            context.SaveChanges();
        }
    }
}

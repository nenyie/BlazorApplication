using BlazorMentorApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMentorApp.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Mentors> Mentors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Mentors>().HasData(new Mentors
            {
                MentorsId = 1,
                FirstName = "john",
                LastName = "wick",
                Email = "johnWick@gmail.com",
                Username = "JW",
                PhotoPath = "images/car2.jpeg",
               
            });

            modelBuilder.Entity<Mentors>().HasData(new Mentors
            {

                MentorsId = 2,
                FirstName = "jane",
                LastName = "wick",
                Email = "janeWick@gmail.com",            
                Username = "JW",
                PhotoPath = "images/car3.jpeg"
            });
        }

    }
}

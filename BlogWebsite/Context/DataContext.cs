using System;
using BlogWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogWebsite.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<AuthorModel> Authors { get; set; }

        public DbSet<BlogModel> Blogs { get; set; }
    }
}

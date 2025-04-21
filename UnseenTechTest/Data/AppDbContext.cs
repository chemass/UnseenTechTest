   using Microsoft.EntityFrameworkCore;
   using UnseenTechTest.Models;

   namespace UnseenTechTest.Data
   {
       public class AppDbContext : DbContext
       {
           public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
            {
                Database.EnsureCreated();
            }

           public DbSet<WordEntry> Words { get; set; }
       }
   }
   
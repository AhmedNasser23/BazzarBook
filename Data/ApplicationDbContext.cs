﻿using BazzarBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BazzarBook.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		// This line will create table in database
		public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().
				HasData(
					new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
						 new Category { Id = 2, Name = "Scifi", DisplayOrder = 2 },
						 new Category { Id = 3, Name = "History", DisplayOrder = 3 }
				);
		}

	}
}
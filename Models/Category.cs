﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BazzarBook.Models
{
	public class Category
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(30)]
		[DisplayName("Category Name")]
		public string Name { get; set; }
		[DisplayName("Dispaly Order")]
		[Range(1, 100, ErrorMessage = "Dispaly Order must be between 1-100.")]
		public int DisplayOrder { get; set; }
	}
}
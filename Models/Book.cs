using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Models
{
    public class Book
    {
        public int Id { get; set; }
		[StringLength(255)]
		[Required(ErrorMessage = "Title is missing.")]
		[Display(Name = "Title")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Author name is missing.")]
		[Display(Name = "Author name")]
		public string AuthorName { get; set; }
		[Required(ErrorMessage = "Genre is missing.")]
		public Genre Genre { get; set; }
		public byte GenreId { get; set; }
		public DateTime DateAdded { get; set; }
		[Display(Name="Release Date")]
		[Required(ErrorMessage ="Release date is missing.")]
		public DateTime ReleaseDate { get; set; }
		[Display(Name="Number in Stock")]
		[Required(ErrorMessage = "Information about quantity in stock is missing.")]
		[Range(1,20,ErrorMessage ="Number must be between 1 and 20")]
		public int NumberInStock { get; set; }
		[Display(Name = "Available quantity")]
		[Required(ErrorMessage = "Information about available quantity is missing.")]
		public int NumberAvailable { get; set; }
	}

}

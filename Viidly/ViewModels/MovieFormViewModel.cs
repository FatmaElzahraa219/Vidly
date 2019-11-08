using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Viidly.Models;
using System.ComponentModel.DataAnnotations;
namespace Viidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }
        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        [Required]
        public byte NumInStock { get; set; }
        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumInStock = movie.NumInStock;
            GenreId = movie.GenreId;
        }
    }
} 
    

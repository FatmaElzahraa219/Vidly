﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Viidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }
        public DateTime DateAdded { get; set; }
        [Display(Name = "Release Date")]

        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Number In Stock")]
        [Range(1,20)]
        public byte NumInStock { get; set; }
    }

}
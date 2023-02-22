using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    // create class for all the fields in the database
    public class MovieFormResponse
    {
        [Key]
        [Required]
        public int ApplicationID { get; set; }
        [Required(ErrorMessage = "The Title is required" )]
        public string Title { get; set; }
        [Required(ErrorMessage = "The Year is required")]
        public string Year { get; set; }
        [Required(ErrorMessage = "The Director is required")]
        public string Director { get; set; }
        [Required(ErrorMessage = "The Rating is required")]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }
        [Required(ErrorMessage = "The Category is required")]
        // foreign key
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}

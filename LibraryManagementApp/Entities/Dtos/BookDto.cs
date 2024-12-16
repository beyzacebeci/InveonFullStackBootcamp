using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record BookDto

    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Title is required.")]
        public string? Title { get; set; }
      
        [Required(ErrorMessage = "Author is required.")]
        public string? Author { get; set; }
        public int PublicationYear { get; set; }
        public string? ISBN { get; set; }
        public string? Genre { get; set; }
        public string? Publisher { get; set; }
        public int PageCount { get; set; }
        public string? Language { get; set; }
        public string? Summary { get; set; }
        public int AvailableCopies { get; set; }
    }
}

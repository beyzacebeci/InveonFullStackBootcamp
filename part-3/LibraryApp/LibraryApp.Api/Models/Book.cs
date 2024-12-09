using Microsoft.AspNetCore.Server.IISIntegration;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Api.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public bool IsDeleted { get; set; }
        private Book() { }

        // Factory Method 
        public static Book Create(string title, string genre)
        {
            if (string.IsNullOrWhiteSpace(title) )
                throw new ArgumentException("Title cannot be empty.", nameof(title));

            if (string.IsNullOrWhiteSpace(genre))
                throw new ArgumentException("Genre cannot be empty.", nameof(genre));
            
            return new Book
            {
                Title = title,
                Genre = genre,
            };
        }

        public void Update(string title, string genre)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.", nameof(title));

            if (string.IsNullOrWhiteSpace(genre))
                throw new ArgumentException("Genre cannot be empty.", nameof(genre));

            Title = title;
            Genre = genre;
        }
    }
}

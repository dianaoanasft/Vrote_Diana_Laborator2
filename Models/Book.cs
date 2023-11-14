using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Vrote_Diana_Laborator2.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Display(Name = "Book Title")]
        [Required(ErrorMessage = "The Title field is required.")]
        [MaxLength(150, ErrorMessage = "The Title field must be at most 150 characters.")]
        [MinLength(3, ErrorMessage = "The Title field must be at least 3 characters.")]
        public string? Title { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]

        public decimal Price { get; set; }

        [DataType(DataType.Date)] 
        public DateTime? PublishingDate { get; set; }

        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; }

        public int? AuthorID { get; set; }
        public Author? Author { get; set; }

        public int? BorrowingID { get; set; }
        public Borrowing? Borrowing { get; set; }

        public ICollection<BookCategory>? BookCategories { get; set; }

    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksInventory.Models
{
    public class BookType
    {
        [Key] [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName ="varchar(500)")]
        public string Author { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        [DisplayName("Book Cover Type")]
        public string covertype { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        [StringLength(10, ErrorMessage = "ISBN cannot exceed 10 characters")]
        public string ISBN { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        [DisplayName("Cover Image")]
        public string coverimage { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [DisplayName("Price")]
        public decimal unitprice { get; set; }

        [Required]
        [DisplayName("Date Created")]
        public DateTime datecreated { get; set; } = Convert.ToDateTime(DateTime.Now.ToString("dd MMMM yyyy"));
    }
}
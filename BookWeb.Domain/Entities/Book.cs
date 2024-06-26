using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookWeb.Domain.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Autor(a)")]
        public string Author { get; set; }

        [DisplayName("Editora")]
        public string Publisher { get; set; }
    }
}

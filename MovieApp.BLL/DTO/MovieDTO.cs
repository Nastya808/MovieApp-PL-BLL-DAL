using System.ComponentModel.DataAnnotations;

namespace MovieApp.BLL.DTO
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Genre { get; set; }

        [Range(1900, 2100)]
        public int Year { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }


    }
}
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.API.Dtos
{
    public class ProductForCreationDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
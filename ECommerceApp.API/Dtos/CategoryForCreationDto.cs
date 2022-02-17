using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.API.Dtos
{
    public class CategoryForCreationDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using Rubin2000.Models.Enums;

using static Rubin2000.Models.DataConstants.EFAttributeConstants;

namespace Rubin2000.Models
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        [MaxLength(IdDefaultLength)]
        public string Id { get; set; }

        [Required]
        [MaxLength(OccupationNameDefaultLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(OccupationNameDefaultLength)]
        public string CompanyName { get; set; }

        public ProductStatus Status { get; set; }

        public decimal Price { get; set; }

        public decimal? PercantageDiscount { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}

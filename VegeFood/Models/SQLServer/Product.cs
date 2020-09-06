using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VegeFood.Models.SQLServer
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "CategoryId is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [StringLength(100)]
        public string Image { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Sale is required")]
        public int Sale { get; set; }

        [StringLength(100)]
        public int Description { get; set; }

        [StringLength(100)]
        public int Status { get; set; }
    }
}

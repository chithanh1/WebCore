using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VegeFood.Support;

namespace VegeFood.Models.SQLServer
{
    [Table("Products")]
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
        [Range(0, Int32.MaxValue)]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, Int32.MaxValue)]
        public int Price { get; set; }

        [Required(ErrorMessage = "Sale is required")]
        [Range(0, 100)]
        public int Sale { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(100)]
        [IncludeArray(true, CheckArray = new object[] { "enable", "disable" }, ErrorMessage = "Status is enable or disable")]
        public string Status { get; set; }
    }

    public class UpdateProductInfo
    {
        [Required]
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Amount { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Price { get; set; }

        [Range(0, 100)]
        public int Sale { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(100)]
        [IncludeArray(true, CheckArray = new object[] { "enable", "disable" }, ErrorMessage = "Status is enable or disable")]
        public string Status { get; set; }
    }
}

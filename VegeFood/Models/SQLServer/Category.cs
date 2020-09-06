using System.ComponentModel.DataAnnotations;

namespace VegeFood.Models.SQLServer
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Type is required")]
        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(100)]
        public string Node { get; set; }
    }
}

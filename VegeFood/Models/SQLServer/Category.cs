using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VegeFood.Models.SQLServer
{
    [Table("category")]
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

    public class UpdateCategoryInfo
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(100)]
        public string Node { get; set; }
    }
}

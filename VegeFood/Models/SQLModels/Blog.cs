using System;
using System.ComponentModel.DataAnnotations;

namespace VegeFood.Models.SQLModels
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "CategoryId is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(500)]
        public string Title { get; set; }

        [Required(ErrorMessage = "PreviewImage is required")]
        [StringLength(200)]
        public string PreviewImage { get; set; }

        [Required(ErrorMessage = "PreviewText is required")]
        [StringLength(500)]
        public string PreviewText { get; set; }

        [Required(ErrorMessage = "CreateAt is required")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime CreateAt { get; set; }
    }
}

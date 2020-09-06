using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VegeFood.Support;

namespace VegeFood.Models.SQLServer
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(17, 90, ErrorMessage = "Age between 17 and 90")]
        public string Age { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(100)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(200)]
        public string Password { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? Birthday { get; set; }

        [Required(ErrorMessage = "Sex is required")]
        [StringLength(10)]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(50)]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(50)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Type is required")]
        [IncludeArray(CheckArray = new object[] { "admin", "user", "customer"})]
        [StringLength(10)]
        public string Type { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime CreateAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime UpdateAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime LastLogin { get; set; }

        [StringLength(100)]
        public string Node { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [IncludeArray(CheckArray = new object[] { "enable", "disable"})]
        [StringLength(10)]
        public string Status { get; set; }
    }
}

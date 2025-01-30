using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Title is required.")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Password { get; set; }
        public ICollection<Transaction> Transactions { get; set; }




    }
}

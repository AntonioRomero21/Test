using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HysonMaintainXOrders.Shared.Entities
{
    [Table("user_account")]
    public class UserAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("number")]
        [MaxLength(100)]
        public String? Number { get; set; }
        [Column("first_name")]
        [MaxLength(100)]
        public String? FirstName { get; set; }
        [Column("last_name")]
        [MaxLength(100)]
        public String? LastName { get; set; }
        [Column("email")]
        [MaxLength(100)]
        public String? Email { get; set; }
        [Column("password")]
        [MaxLength(100)]
        public String? Password { get; set; }


        public ICollection<UserAccountRoles> UserAccountRoles { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HysonMaintainXOrders.Shared.Entities
{
    [Table("user_account_roles")]
    public class UserAccountRoles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_user_account")]
        public int UserAccountId { get; set; }

        [Column("user_roles")]
        public string? RoleName { get; set; }
      
    }
}

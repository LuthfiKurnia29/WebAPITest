using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDOT.Models
{
    [Table("t_user", Schema = "v1")]
    public class User
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("namaLengkap")]
        public string NamaLengkap { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("no_telepon")]
        public string NoTelepon { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}

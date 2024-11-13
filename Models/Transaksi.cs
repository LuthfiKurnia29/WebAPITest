using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestDOT.Models
{
    [Table("t_transaksi", Schema = "v1")]
    public class Transaksi
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("user_id")]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Column("produk_id")]
        public Guid ProdukId { get; set; }
        [ForeignKey("ProdukId")]
        public Products Products { get; set; }
        [Column("jumlah_beli")]
        public int JumlahBeli { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}

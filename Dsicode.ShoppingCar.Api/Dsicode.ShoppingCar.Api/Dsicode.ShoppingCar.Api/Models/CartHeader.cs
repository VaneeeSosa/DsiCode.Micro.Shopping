using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dsicode.ShoppingCart.Api.Models
{
    public class CartHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Importante para MySQL
        public int CartHeaderId { get; set; }

        [Required]
        [Column(TypeName = "varchar(36)")] // Compatible con GUIDs
        public string UserId { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string? CouponCode { get; set; }  // Permitir nulos

        [NotMapped]
        public double Discount { get; set; }

        [NotMapped]
        public double CartTotal { get; set; }

        // ← Aquí la propiedad de navegación
        public virtual ICollection<CartDetails> CartDetails { get; set; }
            = new List<CartDetails>();
    }
}
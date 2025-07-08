using Dsicode.ShoppingCart.Api.Models.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dsicode.ShoppingCart.Api.Models
{
    public class CartDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartDetailsId { get; set; }

        public int CartHeaderId { get; set; }

        [ForeignKey("CartHeaderId")]
        public virtual CartHeader CartHeader { get; set; }  // Usar virtual para proxies

        public int ProductId { get; set; }

        [NotMapped]
        public ProductDto ProductDto { get; set; }

        [Required]
        public int Count { get; set; }
    }
}
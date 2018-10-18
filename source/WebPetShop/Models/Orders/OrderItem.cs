using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebPetShop.Models.Animals;


/*--------------------------------------
 * Project.......: WebPetShop
 * Author........: Ronaldo Torre
 * Date..........: Oct/2018
 * --------------------------------------
 */
namespace WebPetShop.Models.Orders
{
    [Table("OrdersItem")]
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdOrderItem", TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "PedidoId", AutoGenerateFilter = false)]
        [Column("OrderId", TypeName = "int")]
        public int OrderId { get; set; }

        [Column("AnimalType", TypeName = "int")]
        public int AnimalType { get; set; }

        [Column("AnimalId", TypeName = "int")]
        public int AnimalId { get; set; }

        [ForeignKey("AnimalId")]
        public virtual Animal Animal { get; set; }

        [Required]
        [DataType(DataType.Currency, ErrorMessage = "Valor Inválido!")]
        [Display(Name = "Valor", AutoGenerateFilter = false)]
        [Range(0.00, 9999.00)]
        [Column("Price")]
        public decimal? Price { get; set; }

        [Required]
        [Display(Name = "Qtde", AutoGenerateFilter = false)]
        [Column("Amount", TypeName = "int")]
        public int Amount { get; set; }

        [Required]
        [DataType(DataType.Currency, ErrorMessage = "Valor Inválido!")]
        [Display(Name = "Item", AutoGenerateFilter = false)]
        [Range(0.00, 9999.00)]
        [Column("PriceUnit")]
        public decimal? PriceUnit { get; set; }

        [NotMapped]
        public int OrderType { get; set; }

        public OrderItem()
        {
            Animal = new Animal();
        }

    }
}
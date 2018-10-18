using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebPetShop.Models.People;


/*--------------------------------------
 * Project.......: WebPetShop
 * Author........: Ronaldo Torre
 * Date..........: Oct/2018
 * --------------------------------------
 */
namespace WebPetShop.Models.Orders
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdOrder", TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tipo", AutoGenerateFilter = false)]
        [Column("Type", TypeName = "int")]
        public int Type { get; set; }

        [Required]
        [Column("PersonId", TypeName = "int")]
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        [Display(Name = "Pessoa")]
        public virtual Person Person { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Total", AutoGenerateFilter = false)]
        [Range(0, 9999.00, ErrorMessage = "Valor Inválido, pois deve permitir de 1,00 a 99999,00")]
        [Column("Total")]
        public decimal Total { get; set; }

        [Column("Situation")]
        public string Situation { get; set; }

        [Required]
        [Column("AddDate", TypeName = "datetime")]
        public DateTime AddDate { get; set; }

        [Required]
        [MaxLength(25)]
        [Column("AddUser")]
        public string AddUser { get; set; }

        [Column("UpdateDate", TypeName = "datetime")]
        public DateTime? EditDate { get; set; }

        [Column("UpdateUser")]
        public string EditUser { get; set; }

        public virtual List<OrderItem> Itens { get; set; }
        
        public Order()
        {
            Person = new Person();
            Itens = new List<OrderItem>();
        }

    }
}
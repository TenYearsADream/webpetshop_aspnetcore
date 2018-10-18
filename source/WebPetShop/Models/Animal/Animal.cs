using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


/*--------------------------------------
 * Project.......: WebPetShop
 * Author........: Ronaldo Torre
 * Date..........: Oct/2018
 * --------------------------------------
 */
namespace WebPetShop.Models.Animals
{
    [Table("Animal")]
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdAnimal", TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tipo", AutoGenerateFilter = false)]
        [Column("TypeId", TypeName = "int")]
        public int Type { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Raça", AutoGenerateFilter = false)]
        [Column("Specie")]
        public string Specie { get; set; }
        
        [Display(Name = "Descrição", AutoGenerateFilter = false)]
        [Column("Description")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Nascimento", AutoGenerateFilter = false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Column("BirthDate", TypeName = "date")]
        public DateTime? Birthdate { get; set; }

        [Required]
        [Display(Name = "Qtde", AutoGenerateFilter = false)]
        [Column("Amount", TypeName = "int")]
        public int Amount { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Valor", AutoGenerateFilter = false)]
        [Range(0, 9999.00, ErrorMessage = "Valor Inválido, pois deve permitir de 1,00 a 99999,00")]
        [Column("Price")]
        public decimal? Price { get; set; }

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

        public Animal() { }

        public string getAnimalTypeById(int id)
        {
            AnimalType type = new AnimalType();
            return type.GetLabel("Animals", id);
        }

    }
}
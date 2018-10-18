using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


/*--------------------------------------
 * Project.......: WebPetShop
 * Author........: Ronaldo Torre
 * Date..........: Oct/2018
 * --------------------------------------
 */
namespace WebPetShop.Models.UserSys
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdUserProfile", TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Nome", AutoGenerateFilter = false)]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(5)]
        [Display(Name = "Sigla", AutoGenerateFilter = false)]
        [Column("Initials")]
        public string Initial { get; set; }

        [Display(Name = "Descrição", AutoGenerateFilter = false)]
        [Column("Description")]
        public string Description { get; set; }

        [Required]
        [Column("AddDate", TypeName = "datetime")]
        public DateTime AddDate { get; set; }

        [Column("UpdateDate", TypeName = "datetime")]
        public DateTime? EditDate { get; set; }

    }
}
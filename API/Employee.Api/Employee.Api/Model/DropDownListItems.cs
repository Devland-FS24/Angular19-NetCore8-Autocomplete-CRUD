using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Api.Model
{
    
    public class DropDownListItems
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int ddlistId { get; set; }
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string itemType { get; set; }


    }
}

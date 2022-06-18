using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValidaTecAPI.Models
{
    public class Courses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NameCourse { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateStart { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateEnd { get; set; }
        public int Duration { get; set; }
        public string Catedratic { get; set; }
        public string Status { get; set; }
        public string Folio { get; set; }
        [Required]
        public int UserId { get; set; } // crear indice fk
       
        public int CarrerId { get; set; } // fk
    }
}

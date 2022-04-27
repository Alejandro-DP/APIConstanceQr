using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValidaTecAPI.Models
{
    public class Users_Courses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }//indice y Fk
        [Required]
        public int CourseId { get; set; } // indeice y Fk
        
        public string Qualification { get; set; }

    }
}

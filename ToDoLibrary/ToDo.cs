

using System.ComponentModel.DataAnnotations;

namespace ToDoLibrary
{
    public partial class ToDo
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        public string Task { get; set; }
        
        [Required] 
        public string Status { get; set; }
        //public DateTime DueDate { get; set; }
    }
}

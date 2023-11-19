using System.ComponentModel.DataAnnotations;

namespace ToDoList.Data.Entities
{
    public class ToDo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "That's too long!")]
        public string? Description { get; set; }

        [Required]
        public bool IsCompleted { get; set; } = false;
    }
}

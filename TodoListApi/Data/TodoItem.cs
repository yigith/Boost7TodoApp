using System.ComponentModel.DataAnnotations;

namespace TodoListApi.Data
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Required, MaxLength(400)]
        public string Title { get; set; }

        public bool IsDone { get; set; }
    }
}

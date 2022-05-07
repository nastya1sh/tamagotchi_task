using Microsoft.AspNetCore.Mvc;

namespace tamagotchi_task.Models.ViewModels
{
    public class TaskModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Difficulty { get; set; }
        [Required]
        public string Tag { get; set; }
        [BindProperty, DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DeadLine { get; set; }
    }
}

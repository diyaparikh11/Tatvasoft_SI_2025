using System.ComponentModel.DataAnnotations;

namespace Mission.Entities.Models
{
    public class MissionTheme
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }
    }
}

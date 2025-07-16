using System.ComponentModel.DataAnnotations;

namespace Mission.Entities.Models
{
    public class MissionModel
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Theme { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        // Add more properties as needed
    }
}

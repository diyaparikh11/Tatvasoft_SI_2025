namespace Mission.Entities.Models
{
    public class MissionApplication
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MissionId { get; set; }
        public DateTime AppliedDate { get; set; } = DateTime.Now;

        public User? User { get; set; }
        public MissionModel? Mission { get; set; }
    }
}
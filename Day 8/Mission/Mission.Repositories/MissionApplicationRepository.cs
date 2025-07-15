using Mission.Entities.Models;

namespace Mission.Repositories
{
    public class MissionApplicationRepository : IMissionApplicationRepository
    {
        private readonly MissionDBContext _context;

        public MissionApplicationRepository(MissionDBContext context)
        {
            _context = context;
        }

        public IEnumerable<MissionApplication> GetAll() => _context.MissionApplications.ToList();

        public MissionApplication? GetById(int id) => _context.MissionApplications.FirstOrDefault(x => x.Id == id);

        public void Add(MissionApplication app)
        {
            _context.MissionApplications.Add(app);
            _context.SaveChanges();
        }

        public void Update(MissionApplication app)
        {
            _context.MissionApplications.Update(app);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var app = GetById(id);
            if (app != null)
            {
                _context.MissionApplications.Remove(app);
                _context.SaveChanges();
            }
        }

        public IEnumerable<MissionApplication> GetByUserId(int userId)
        {
            return _context.MissionApplications.Where(x => x.UserId == userId).ToList();
        }
    }
}

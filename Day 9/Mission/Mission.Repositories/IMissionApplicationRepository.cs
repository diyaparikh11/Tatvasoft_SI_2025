using Mission.Entities.Models;

namespace Mission.Repositories
{
    public interface IMissionApplicationRepository
    {
        IEnumerable<MissionApplication> GetAll();
        MissionApplication? GetById(int id);
        void Add(MissionApplication application);
        void Update(MissionApplication application);
        void Delete(int id);
        IEnumerable<MissionApplication> GetByUserId(int userId);
    }
}
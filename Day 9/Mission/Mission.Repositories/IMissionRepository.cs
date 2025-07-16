using Mission.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IMissionRepository
{
    Task<IEnumerable<MissionModel>> GetAllMissionsAsync();
    Task<MissionModel> AddMissionAsync(MissionModel mission);
}

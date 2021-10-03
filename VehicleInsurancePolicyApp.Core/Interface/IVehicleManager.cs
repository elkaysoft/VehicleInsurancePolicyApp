using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInsurancePolicyApp.Core.DTO;

namespace VehicleInsurancePolicyApp.Core.Interface
{
    public interface IVehicleManager
    {
        ResponseMgr<List<GetVehicleDto>> GetVehicleDetails();
        ResponseMgr<List<GetVehicleDto>> GetVehicleModelByMake(string maker);
    }
}

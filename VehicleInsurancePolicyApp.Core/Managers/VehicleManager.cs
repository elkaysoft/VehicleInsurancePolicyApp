using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInsurancePolicyApp.Core.DTO;
using VehicleInsurancePolicyApp.Core.Interface;

namespace VehicleInsurancePolicyApp.Core.Managers
{
    public class VehicleManager : IVehicleManager
    {
        private readonly AppDbContext _context;

        public VehicleManager(AppDbContext context)
        {
            _context = context;
        }

        public ResponseMgr<List<GetVehicleDto>> GetVehicleDetails()
        {
            var result = new ResponseMgr<List<GetVehicleDto>>()
            {
                code = 01,
                description = "Failed"
            };

            try
            {
                var vehiclesInfos = _context.VehiclesInfos.ToList();
                var filteredRecord = vehiclesInfos.OrderBy(x => x.VehicleMake).GroupBy(x => x.VehicleMake)
                    .Select(p => p.FirstOrDefault()).ToList();
                if (filteredRecord.Any())
                {
                    var resp = new List<GetVehicleDto>();
                    resp = filteredRecord.Select(c => new GetVehicleDto
                    {
                        VehicleMake = c.VehicleMake,
                        VehicleModel = c.VehicleModel,
                        Id = c.Id
                    }).ToList();

                    result.data = resp;
                    result.code = 200;
                    result.description = "Successful";
                }
            }
            catch
            {
                result.code = 99;
                result.description = "Oops! Something went wrong";
            }

            return result;
        }

        public ResponseMgr<List<GetVehicleDto>> GetVehicleModelByMake(string maker)
        {
            var result = new ResponseMgr<List<GetVehicleDto>>()
            {
                code = 01,
                description = "Failed"
            };

            try
            {
                var vehiclesInfos = _context.VehiclesInfos.Where(x => x.VehicleMake == maker).ToList();
                if (vehiclesInfos.Any())
                {
                    var resp = new List<GetVehicleDto>();
                    resp = vehiclesInfos.Select(c => new GetVehicleDto
                    {
                        VehicleMake = c.VehicleMake,
                        VehicleModel = c.VehicleModel,
                        Id = c.Id
                    }).ToList();

                    result.data = resp;
                    result.code = 200;
                    result.description = "Successful";
                }
            }
            catch
            {
                result.code = 99;
                result.description = "Oops! Something went wrong";
            }

            return result;
        }


    }
}

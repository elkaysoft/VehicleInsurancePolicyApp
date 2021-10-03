using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInsurancePolicyApp.Core.DTO
{
    public class GetVehicleDto
    {
        public Int64 Id { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
    }
}

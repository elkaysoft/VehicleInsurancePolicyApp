using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInsurancePolicyApp.Core.DTO
{
    public class GetPolicyDto
    {
        public Int64 Id { get; set; }
        public string BodyType { get; set; }
        public int Amount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInsurancePolicyApp.Core.DTO;
using VehicleInsurancePolicyApp.Core.Interface;
using VehicleInsurancePolicyApp.Core.Models;

namespace VehicleInsurancePolicyApp.Core.Managers
{
    public class PolicyManager : IPolicyManager
    {
        private readonly AppDbContext _context;

        public PolicyManager(AppDbContext context)
        {
            _context = context;
        }

        public ResponseMgr<List<GetPolicyDto>> GetInsurancePolicies()
        {
            var result = new ResponseMgr<List<GetPolicyDto>>() 
            { 
                code = 01,
                description = "Failed"
            };

            try
            {
                var policyInfo = _context.PolicyPrices.ToList();
                if (policyInfo.Any())
                {
                    var resp = new List<GetPolicyDto>();
                    resp = policyInfo.Select(c => new GetPolicyDto
                    {
                        Amount = c.Amount,
                        BodyType = c.BodyType,
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

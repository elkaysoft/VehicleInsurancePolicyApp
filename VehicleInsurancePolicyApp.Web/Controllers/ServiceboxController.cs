using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleInsurancePolicyApp.Core.DTO;
using VehicleInsurancePolicyApp.Core.Interface;

namespace VehicleInsurancePolicyApp.Web.Controllers
{
    public class ServiceboxController : Controller
    {
        private readonly IPolicyManager _policyManager;
        private readonly IVehicleManager _vehicleManager;

        public ServiceboxController(IPolicyManager policyManager, IVehicleManager vehicleManager)
        {
            _policyManager = policyManager;
            _vehicleManager = vehicleManager;
        }

        [HttpGet]
        public IActionResult GetPremiumPolicy()
        {
            var result = new ResponseMgr<List<GetPolicyDto>>();

            try
            {
                var resp = _policyManager.GetInsurancePolicies();
                if (resp.code.Equals(200))
                {
                    result.code = resp.code;
                    result.description = resp.description;
                    result.data = resp.data;
                    return Ok(result);
                }
                else
                {
                    result.code = resp.code;
                    result.description = resp.description;
                    return BadRequest(result);
                }
            }
            catch
            {
                result.code = 99;
                result.description = "Something went wrong, pls try again later";
                return BadRequest(result);
            }
        }


        [HttpGet]
        public IActionResult GetVehicleListings()
        {
            var result = new ResponseMgr<List<GetVehicleDto>>();

            try
            {
                var resp = _vehicleManager.GetVehicleDetails();
                if (resp.code.Equals(200))
                {
                    result.code = resp.code;
                    result.description = resp.description;
                    result.data = resp.data;
                    return Ok(result);
                }
                else
                {
                    result.code = resp.code;
                    result.description = resp.description;
                    return BadRequest(result);
                }
            }
            catch
            {
                result.code = 99;
                result.description = "Something went wrong, pls try again later";
                return BadRequest(result);
            }
        }

        [HttpGet]
        public IActionResult GetVehicleModelsByMake(string maker)
        {
            var result = new ResponseMgr<List<GetVehicleDto>>();

            try
            {
                var resp = _vehicleManager.GetVehicleModelByMake(maker);
                if (resp.code.Equals(200))
                {
                    result.code = resp.code;
                    result.description = resp.description;
                    result.data = resp.data;
                    return Ok(result);
                }
                else
                {
                    result.code = resp.code;
                    result.description = resp.description;
                    return BadRequest(result);
                }
            }
            catch
            {
                result.code = 99;
                result.description = "Something went wrong, pls try again later";
                return BadRequest(result);
            }
        }


    }
}

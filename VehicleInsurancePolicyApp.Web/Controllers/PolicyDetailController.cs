using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleInsurancePolicyApp.Web.Controllers
{
    public class PolicyDetailController : Controller
    {
        public IActionResult GetVehicles()
        {
            return View();
        }
    }
}

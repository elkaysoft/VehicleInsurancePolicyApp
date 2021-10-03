using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInsurancePolicyApp.Core.Models;

namespace VehicleInsurancePolicyApp.Core
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
        }

        public DbSet<PurchaseInfo> Purchases { get; set; }
        public DbSet<PolicyPrices> PolicyPrices { get; set; }
        public DbSet<VehiclesInfo> VehiclesInfos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInsurancePolicyApp.Core.Models
{
    public class PolicyPrices
    {
        [Key]
        public Int64 Id { get; set; }
        public string BodyType { get; set; }
        public int Amount { get; set; }
        public bool IsDeleted { get; set; }
        public string SubmittedBy { get; set; }
        public DateTime SubmittedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }
}

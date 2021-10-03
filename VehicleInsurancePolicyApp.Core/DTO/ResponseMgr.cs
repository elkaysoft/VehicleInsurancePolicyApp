using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInsurancePolicyApp.Core.DTO
{
    public class ResponseMgr
    {
        public int code { get; set; }
        public string description { get; set; }
    }

    public class ResponseMgr<T>: ResponseMgr
    {
        public T data { get; set; }
    }
}

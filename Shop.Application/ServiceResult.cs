using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application
{
    public class ServiceResult
    {
        public bool Status { get; }
        public string Error { get; }

        public ServiceResult(bool status, string error = null) 
        {
            Status = status;
            Error = error;
        }        
    }
}

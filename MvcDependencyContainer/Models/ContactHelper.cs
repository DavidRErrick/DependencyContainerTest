using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDependencyContainer.Models
{
    public class ContactHelper : IContactHelper
    {
        readonly string message;

        public ContactHelper()
        {
            message = "Message from Contact Helper created at: " + DateTime.Now.ToLongTimeString();
        }
        public string getMessage()
        {
            return message;
        }
    }
}
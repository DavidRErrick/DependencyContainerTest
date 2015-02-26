using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDependencyContainer.Models
{
    public class AboutHelper : IAboutHelper
    {
        public string getMessage()
        {
            return "This is a message from your About Helper";
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDependencyContainer.Models
{
    public class AboutHelper : IAboutHelper
    {
        readonly string message;

        public AboutHelper()
        {
            message = "This is a message from your About Helper created at: " + DateTime.Now.ToLongTimeString(); 
        }
        public string getMessage()
        {
            return message;
        }
    }
}
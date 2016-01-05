using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.WebHost;

namespace Portfolio.Code
{
    public class CustomBufferPolicy : WebHostBufferPolicySelector
    {
        public override bool UseBufferedInputStream(object hostContext)
        {
            return base.UseBufferedInputStream(hostContext);
        }

        public override bool UseBufferedOutputStream(System.Net.Http.HttpResponseMessage response)
        {
            return false;
        }
    }
}
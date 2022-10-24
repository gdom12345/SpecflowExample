using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject2.Api
{
    internal interface BaseCall
    {
        RestClient GetBaseRequest();
    }
}

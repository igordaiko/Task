using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Task.Models;
using System.Web.Mvc;
namespace Task.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values

        // GET api/values/5

        public string Get(CulcModel value)
        {
            
            return "value";
        }

        // POST api/values
        public HttpResponseMessage Post(CulcModel value)
        {
            int result = 0;
            if (value.operation == "+")
                result = value.frs_num + value.scd_num;
            else if (value.operation == "-")
                result = value.frs_num - value.scd_num;
            else if (value.operation == "*")
                result = value.frs_num * value.scd_num;
            else if (value.operation == "/")
            {
                if (value.scd_num != 0)
                    result = value.frs_num / value.scd_num;
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "невозможно поделить на ноль");
            }
                
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

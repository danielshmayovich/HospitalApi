using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HospitalApi.Controllers
{
    public class RolesController : ApiController
    {
        [HttpGet]
        [Route("api/roles/all")]
        public IHttpActionResult SelectAll()
        {
            using (var helper = new SqlHelper("MyHospital"))
            {
                var roles = helper.SelectAsList<Models.Role>("spGetAllRoles");

                return Ok(roles);
            };
        }
    }
}

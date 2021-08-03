using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Data.SqlClient;

namespace HospitalApi.Controllers
{
    public class PersonsController : ApiController
    {
        [HttpGet]
        [Route("api/persons/all")]
        public IHttpActionResult SelectAll()
        {
            using (var helper = new SqlHelper("MyHospital"))
            {
                var persons = helper.SelectAsList<Models.Person>("spGetAllPersons");

                return Ok(persons);
            };
        }

        [HttpPost]
        [Route("api/persons/add")]
        public IHttpActionResult AddNew([FromBody]Models.Person person)
        {
            using (var helper = new SqlHelper("MyHospital"))
            {
                helper.Exec("spInsertNewPerson",
                            new SqlParameter("@Id", person.Id),
                            new SqlParameter("@FirstName", person.FirstName),
                            new SqlParameter("@LastName", person.LastName),
                            new SqlParameter("@Address", person.Address),
                            new SqlParameter("@Phone", person.Phone),
                            new SqlParameter("@Email", person.Email),
                            new SqlParameter("@RoleId", person.RoleId));

                return Ok("yey");
            };
        }

        [HttpPost]
        [Route("api/persons/edit")]
        public IHttpActionResult Update([FromBody]Models.Person person)
        {
            using (var helper = new SqlHelper("MyHospital"))
            {
                helper.Exec("spUpdatePerson",
                            new SqlParameter("@Id", person.Id),
                            new SqlParameter("@FirstName", person.FirstName),
                            new SqlParameter("@LastName", person.LastName),
                            new SqlParameter("@Address", person.Address),
                            new SqlParameter("@Phone", person.Phone),
                            new SqlParameter("@Email", person.Email),
                            new SqlParameter("@RoleId", person.RoleId));

                return Ok("yey");
            };
        }

        [HttpPost]
        [Route("api/persons/remove")]
        public IHttpActionResult Delete([FromBody]string id)
        {
            using (var helper = new SqlHelper("MyHospital"))
            {
                helper.Exec("spDeletePerson", new SqlParameter("@Id", id));

                return Ok(true);
            };
        }
    }
}

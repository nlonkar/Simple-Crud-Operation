using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Dotnet_Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private static List<Employe> employedata = new List<Employe>
            {
                  new Employe
                  {
                      emp_id = 1,
                      firstname = "nikhil",
                      lastname = "lonkar",
                      department = "IT",
                      expireance = 2
                  },

                  new Employe
                  {
                      emp_id = 2,
                      firstname = "prasad",
                      lastname = "phule",
                      department = "dotnet",
                      expireance = 10
                  }
            };
        [HttpGet]
        public async Task<ActionResult<List<Employe>>> get()
        {

            return Ok(employedata);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employe>> getsingal(int id )
        {
            var employe = employedata.Find(x => x.emp_id == id);
            if (employe == null) 
                return BadRequest("No data found aginst id ");
            return Ok(employe);
        }

        [HttpPost]

        public async Task<ActionResult<List<Employe>>> Add_Empoloye(Employe employe)
        {
            employedata.Add(employe);
            return Ok(employedata);
        }

        [HttpPut]
        public async Task<ActionResult<List<Employe>>> Update(Employe request)
        {
            var employe = employedata.Find(x => x.emp_id == request.emp_id);
            if (employe == null)
                return BadRequest("No data found aginst id ");

            employe.firstname = request.firstname;
            employe.lastname = request.lastname;
            employe.department = request.department;
            employe.expireance = request.expireance;
            return Ok(employedata);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employe>>> Delete_Employe(int id)
        {
            var employe = employedata.Find(x => x.emp_id == id);
            if (employe == null)
                return BadRequest("No data found aginst id ");
            employedata.Remove(employe);
            return Ok(employedata);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using officeNow_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace officeNow_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingLogController : ControllerBase
    {
        private readonly OfficeNowContext _context;
        public BookingLogController(OfficeNowContext context)
        {
            _context = context;
        }
        // GET: api/<BookingLogController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingLog>>> Get()
        {
            return await _context.BookingLogs.ToListAsync();
        }

        // GET api/<BookingLogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookingLogController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookingLogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingLogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

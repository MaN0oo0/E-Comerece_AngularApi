using E_Comerece_AngularApi.Errors;
using Infrerastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Comerece_AngularApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : BaseApiController
    {
        private readonly StoreContext db;

        public BugController(StoreContext db)
        {
            this.db = db;
        }

        [HttpGet("NotFound")]
        public IActionResult GetNotFoundRequest()
        {
            var thing = db.Products.Find(50);
            if (thing == null) return NotFound(new ApiResponse(404));
            else
                return Ok();
        }

        [HttpGet("ServerError")]
        public IActionResult GetServerError()
        {
            var thing = db.Products.Find(50);
            var catchNull = thing.ToString();
            return Ok();
        }
        [HttpGet("BadRequests")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("BadRequests/{Id}")]
        public IActionResult GetNotFoundRequest(int Id)
        {
            return Ok();
        }

    }
}

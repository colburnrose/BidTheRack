using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorController : BaseApiController
    {
        private readonly StoreContext _context;
        public ErrorController(StoreContext context) { _context = context; }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var request = _context.Products.Find(42);

            if(request == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var request = _context.Products.Find(42);

            var respone = request.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}

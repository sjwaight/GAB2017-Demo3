using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiliconValve.Gab2017.DemoWebCore.Services;

namespace SiliconValve.Gab2017.DemoWebCore.Controllers
{
    [Produces("application/json")]
    public class PostcodeController : Controller
    {
        [HttpGet]
        [Route("api/postcode/{postcode}")]
        public IActionResult Get(string postcode)
        {
            if (string.IsNullOrEmpty(postcode))
            {
                return BadRequest();
            }

            var result = PostcodeDataStore.Instance.Where(pc => pc.PostCode == postcode);

            if (result != null && result.Count() > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/postcode/state/{state}")]
        public IActionResult GetByState(string state)
        {
            if (string.IsNullOrEmpty(state))
            {
                return BadRequest();
            }

            var result = PostcodeDataStore.Instance.Where(pc => pc.State.Equals(state, StringComparison.OrdinalIgnoreCase));

            if (result != null && result.Count() > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/postcode/suburb/{suburb}")]
        public IActionResult GetBySuburb(string suburb)
        {
            if (string.IsNullOrEmpty(suburb))
            {
                return BadRequest();
            }

            var result = PostcodeDataStore.Instance.Where(pc => pc.Suburb.Contains(suburb.ToUpper()));

            if (result != null && result.Count() > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
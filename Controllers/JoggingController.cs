using MagicVilla.Models;
using MagicVilla.Data;
using Microsoft.AspNetCore.Mvc;


namespace MagicVilla.Controllers
{
    [Route("api/Jogging")]
    [ApiController]
    public class JoggingController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Jogging>> GetAllJogging()
        {
            return joggingStore.joggingList;
        }
        
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult GetJogging(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id == null)
            {
                return BadRequest();
            }
            var Jogging = joggingStore.joggingList.FirstOrDefault(j => j.ID.ToString() == id);
            if(Jogging == null)
            {
                return NotFound();
            }
            return Ok(Jogging);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Jogging> CreateJogging([FromBody]Jogging jogging)
        {
            if(jogging == null)
            {
                return BadRequest(jogging);
            }
            jogging.ID = Guid.NewGuid();
            joggingStore.joggingList.Add(jogging);
            return Ok(jogging);
        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteJogging(string id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var jogging = joggingStore.joggingList.FirstOrDefault(j => j.ID.ToString() == id);
            if(jogging == null)
            {
                return NotFound();
            }
            joggingStore.joggingList.Remove(jogging);
            return NoContent();
        }

        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateJogging(string id, [FromBody]Jogging joggingpram)
        {
            if(id == null || joggingpram.ID.ToString() != id)
            {
                return BadRequest();
            }
            var jogging = joggingStore.joggingList.FirstOrDefault(j => j.ID.ToString() == id);
            if(jogging == null)
            {
                return NotFound();
            }
            jogging.Distance = joggingpram.Distance;
            jogging.Date = joggingpram.Date;
            return NoContent();
        }


    }
}

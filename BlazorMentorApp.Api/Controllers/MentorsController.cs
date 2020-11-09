using BlazorMentorApp.Api.Models;
using BlazorMentorApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMentorApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorsController : ControllerBase
    {
        private readonly IMentorRepository mentorRepository;

        public MentorsController(IMentorRepository mentorRepository)
        {
            this.mentorRepository = mentorRepository;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Mentors>>> Search(string name)
        {
            try
            {
               var result = await mentorRepository.Search(name);

                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {

              throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetMentors()
        {
            try
            {
                return Ok(await mentorRepository.GetMentors());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }

      //  [HttpGet("{id: int}")]  gave an error but fix this
        [HttpGet("{id}")]
        public async Task<ActionResult<Mentors>> GetMentor(int id)
        {
            try
            {
                var result = await mentorRepository.GetMentor(id);

                if(result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
            return null;
        }
        [HttpPost]
        public async Task<ActionResult<Mentors>> CreateMentor(Mentors mentor)
        {
            try
            {
                if(mentor == null)
                {
                    return BadRequest();
                }
                var emp = mentorRepository.GetMentorByEmail(mentor.Email);

                if(emp != null)
                {
                    ModelState.AddModelError("email", "Mentor email already in use");
                    return BadRequest(ModelState);
                }

                var createdMentor = await mentorRepository.AddMentors(mentor);

                return CreatedAtAction(nameof(GetMentor), new { id = createdMentor.MentorsId }, createdMentor); 
            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
            return null;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Mentors>> UpdateMentor(int id, Mentors mentors)
        {
            try
            {
                if(id != mentors.MentorsId)
                {
                    return BadRequest("mentors Id mismatch");
                };
                var mentorToUpdate = await mentorRepository.GetMentor(id);
                if(mentorToUpdate == null)
                {
                    return NotFound($"Mentors with ID = {id} not found");
                }
                return await mentorRepository.UpdateMentors(mentors);
            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
            return null;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mentors>> DeleteMentor(int id)
        {
            try
            {
                var mentorToDelete = await mentorRepository.GetMentor(id);
                if (mentorToDelete == null)
                {
                    return NotFound($"Mentor with ID = {id} not found");
                }
                return await mentorRepository.DeleteMentor(id);
            }       
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
            return null;
        }
    }
}

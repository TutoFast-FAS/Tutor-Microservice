using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutoFast.TutorCatalog.Service.Dtos;
using TutoFast.TutorCatalog.Service.Entities;
using TutoFast.TutorCatalog.Service.Repositories;

namespace TutoFast.TutorCatalog.Service.Controllers
{
    [ApiController]
    [Route("tutors")]
    public class TutorsController : ControllerBase
    {
        private readonly ITutorsRepository tutorsRepository;
        public TutorsController(ITutorsRepository tutorsRepository)
        {
            this.tutorsRepository = tutorsRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<TutorDto>> GetAsync()
        {
            var tutors = (await tutorsRepository.GetAllAsync()).Select(tutor => tutor.AsDto());
            return tutors;
        }
        // GET/tutors/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TutorDto>> GetByIdAsync(Guid id)
        {

            var tutor = await tutorsRepository.GetAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }
            return tutor.AsDto();
        }
        // POST/tutors
        [HttpPost]
        public async Task<ActionResult<TutorDto>> PostAsync(CreateTutorDto createTutorDto)
        {
            var tutor = new Tutor
            {
                Name = createTutorDto.Name,
                Description = createTutorDto.Description,
                FeePerHour = createTutorDto.FeePerHour,
                CreatedDate = DateTimeOffset.Now
            };
            await tutorsRepository.CreateAsync(tutor);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = tutor.Id }, tutor);
        }
        // PUT/tutors/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateTutorDto updateTutorDto)
        {
            var existingTutor = await tutorsRepository.GetAsync(id);
            if (existingTutor == null)
            {
                return NotFound();
            }
            existingTutor.Name = updateTutorDto.Name;
            existingTutor.Description = updateTutorDto.Description;
            existingTutor.FeePerHour = updateTutorDto.FeePerHour;
            await tutorsRepository.UpdateAsync(existingTutor);
            return NoContent();
        }
        // DELETE/tutors/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var tutor = await tutorsRepository.GetAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }
            await tutorsRepository.RemoveAsync(tutor.Id);
            return NoContent();
        }
    }
}
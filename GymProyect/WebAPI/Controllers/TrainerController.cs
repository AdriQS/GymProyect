using System;
using Microsoft.AspNetCore.Mvc;
using Model;
using CoreApp;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
	{
        [HttpPost]
        [Route("CreateTrainer")]
        public async Task<IActionResult> Create(Trainer trainer)
        {
            var tm = new TrainerManager();

            try
            {
                tm.Create(trainer);
                return Ok(trainer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet]
        [Route("RetriveAllTrainers")]
        public async Task<ActionResult> RetriveAll()
        {
            try
            {
                var tm = new TrainerManager();
                return Ok(tm.RetriveAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetriveTrainerById")]
        public async Task<ActionResult> RetrivById(int Id)
        {
            try
            {
                var tm = new TrainerManager();
                var trainer = new Trainer { id = Id };
                return Ok(tm.RetriveById(trainer));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateTrainer")]
        public async Task<IActionResult> Update(Trainer trainer, int id)
        {
            var tm = new TrainerManager();

            try
            {

                tm.Update(trainer, id);
                return Ok(trainer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpDelete]
        [Route("DeleteTrainer")]
        public async Task<IActionResult> Delete(int id)
        {
            var tm = new TrainerManager();

            try
            {
                tm.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}


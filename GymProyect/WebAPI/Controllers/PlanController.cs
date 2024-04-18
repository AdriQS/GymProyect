using System;
using CoreApp;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
	{
        [HttpPost]
        [Route("Createplan")]
        public async Task<IActionResult> Create(Plan plan)
        {
            var pm = new PlanManager();

            try
            {
                pm.Create(plan);
                return Ok(plan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet]
        [Route("RetriveAllPlans")]
        public async Task<ActionResult> RetriveAll()
        {
            try
            {
                var pm = new PlanManager();
                return Ok(pm.RetriveAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrivePlanById")]
        public async Task<ActionResult> RetrivById(int Id)
        {
            try
            {
                var pm = new PlanManager();
                var plan = new Plan { id = Id };
                return Ok(pm.RetriveById(plan));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdatePlan")]
        public async Task<IActionResult> Update(Plan plan, int id)
        {
            var pm = new PlanManager();

            try
            {

                pm.Update(plan, id);
                return Ok(plan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpDelete]
        [Route("DeletePlan")]
        public async Task<IActionResult> Delete(int id)
        {
            var pm = new PlanManager();

            try
            {
                pm.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}


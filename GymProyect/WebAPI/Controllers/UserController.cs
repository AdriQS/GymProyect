using System;
using Microsoft.AspNetCore.Mvc;
using Model;
using CoreApp;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
	{
        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> Create(User user)
        {
            var um = new UserManager();

            try
            {
                um.Create(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet]
        [Route("RetriveAllUsers")]
        public async Task<ActionResult> RetriveAll()
        {
            try
            {
                var um = new UserManager();
                return Ok(um.RetriveAll());
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetriveUserById")]
        public async Task<ActionResult> RetrivById(int Id)
        {
            try
            {
                var um = new UserManager();
                var client = new User { id = Id };
                return Ok(um.RetriveById(client));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> Update(User user, int id)
        {
            var um = new UserManager();

            try
            {

                um.Update(user, id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> Delete(int id)
        {
            var um = new UserManager();

            try
            {
                um.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}


﻿using MicroRentACar.Models;
using MicroRentACar.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroRentACar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            IEnumerable<User> users = await _userRepo.GetUsers();
            return new OkObjectResult(users);
        }

        [HttpGet("GetUserByID/{id}")]
        public async Task<IActionResult> GetUserByID(int id)
        {
            User user = await _userRepo.GetUserByID(id);
            return new OkObjectResult(user);
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            await _userRepo.AddUser(user);
            return new NoContentResult();
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            if (user != null)
            {
                await _userRepo.UpdateUser(user);
                return new OkResult();
            }
            return new NoContentResult();
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userRepo.DeleteUser(id);
            return new OkResult();
        }

        

        [HttpGet("VerificationUser")]
        public async Task<IActionResult> VerificationUser(string Email, string Password)
        {
            bool verificationUser = await _userRepo.VerificationUser(Email, Password);
            return new OkObjectResult(verificationUser);
        }

        [HttpGet("GetUserByPage/{pagenumber}")]
        public async Task<IActionResult> GetUserByPage(int pagenumber)
        {

            IEnumerable<User> users = await _userRepo.GetUsersByPage(pagenumber);
            return new ObjectResult(users);

        }
        [HttpGet("GetUserCount")]
        public async Task<IActionResult> GetUserCount()
        {

            int usersCount = await _userRepo.GetUsersCount();
            return new ObjectResult(usersCount);

        }
    }
}

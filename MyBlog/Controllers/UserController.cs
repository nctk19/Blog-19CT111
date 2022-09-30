using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Data;
using MyBlog.Dto.User;
using MyBlog.Repository;


namespace MyBlog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {


            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult AddUser(CreateUserDto createUserDto)
        {
            if (ModelState.IsValid)
            {
                var user = (new Models.User()
                {
                    DisplayName = createUserDto.DisplayName,
                    Email = createUserDto.Email,
                    Phone = createUserDto.Phone,
                    Address = createUserDto.Address,
                    DateOfBirth = createUserDto.DateOfBirth
                });
                var createdUser = _userRepository.InsertUser(user);
                return Ok(createdUser);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using MyBlog.Data;

namespace MyBlog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController:ControllerBase
    
    {
        private readonly AppDbContext _context;
        public TestController(AppDbContext context) {


            _context=context;
        }


        [HttpGet]
        public IActionResult GetData(){
            return Ok(new
            {
                status="Ok",
                data ="Success"
            });
        }
        [HttpPost]
        public IActionResult PostData(){
            var user=_context.Users.Add(new Models.User(){
                DisplayName="User test",
                Email="test@gmail.com",
                Phone="0988888888",
                Address="HuynhVanNghe",
                DateOfBirth=DateTime.UtcNow
            });
            _context.SaveChanges();
            return Ok(User);
        }
    }
}
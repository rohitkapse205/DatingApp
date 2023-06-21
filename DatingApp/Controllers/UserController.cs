using DatingApp.Data;
using DatingApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DatingApp.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;


        public UserController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUsers>>> GetUsers() 
        {
            var users =await _context.Users.ToListAsync();
            return users;
        }
        [HttpGet("id")]

        public async Task<ActionResult<AppUsers>> GetId(int id) {

            var user =await _context.Users.FindAsync(id);
            return user;



            //  Alernate approach
            //return await _context.Users.FindAsync(id);
        }
    }
}

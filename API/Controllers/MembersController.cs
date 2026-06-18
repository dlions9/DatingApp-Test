using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]   
    
    [ApiController]
    public class MembersController : ControllerBase
    {

        private readonly AppDbContext _context;

        public MembersController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<AppUser>>> GetMembers()
        {
            List<AppUser> users = await _context.Users.ToListAsync();

            return users;
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<AppUser>> GetMember(string id)
        {
            AppUser user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            else 
                return user;
        }


        public async Task<string> Name()
        {
            return "Name";
        }

    }
}

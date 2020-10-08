using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Database;
using UserService.Database.Entities;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public UserController(DatabaseContext context)
        {
            _context = context;
        }
        //// GET: api/User
        //[HttpGet]
        //public IEnumerable<User> Get()
        //{
        //    return _context.Users.ToList();
        //}

        //GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "user1", "user2", "user3", "user4" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return _context.Users.Find(id);
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

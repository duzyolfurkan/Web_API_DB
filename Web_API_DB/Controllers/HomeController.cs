using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Web_API_DB.Model;
using Web_API_DB.Model.Context;

namespace Web_API_DB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        Context _context;
        public HomeController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        [HttpPost]
        public User InsertUser([FromBody]User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        [HttpGet("{id}")]
        public User GetUser(int id) 
        {
            return _context.Users.Find(id);
        }

        [HttpPut]
        public User UpgradeUser([FromBody]User user) 
        {
            var upgradeUser = _context.Users.Where(x => x.UserID == user.UserID).FirstOrDefault();
            upgradeUser.FirstName = user.FirstName;
            upgradeUser.LastName = user.LastName;
            upgradeUser.Address = user.Address;
            _context.SaveChanges();
            return upgradeUser;
        }

        [HttpDelete("{id}")]
        public void DeleteUser(int id) 
        {
            var deleteUser = _context.Users.Where(x => x.UserID == id).FirstOrDefault();
            _context.Users.Remove(deleteUser);
            _context.SaveChanges();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller

    {
       
        private readonly DataContext _context;


        public UserController()
        {
            _context = new DataContext();
        }

        [HttpGet]
        public List<User> Get()
        {
            return _context.Users.ToList();
        }


        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _context.Users.First(u => u.Id == id);
        }
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User updateUser)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("Not Exist for Update");
            }
            user.Id = updateUser.Id;
            user.Name = updateUser.Name;
            user.Email = updateUser.Email;

            _context.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("Not Exist for Delete");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }

}

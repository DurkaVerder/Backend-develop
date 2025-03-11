using Microsoft.AspNetCore.Mvc;

namespace LabWork11.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase
    {
        static List<User> users = new List<User> { new User(0, "Timur", 20) };
        static private int id = 1;

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(InputUser newUser)
        {
            User user = new User(id++ ,newUser.Name, newUser.Age);

            users.Add(user);
            return Ok("Added user");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, InputUser user) {
            var userToUpdate = users.FirstOrDefault(u => u.Id == id);
            if (userToUpdate == null)
            {
                return NotFound("User not found");
            }

            userToUpdate.Name = user.Name;
            userToUpdate.Age = user.Age;
            return Ok("Updated user");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userToDelete = users.FirstOrDefault(u => u.Id == id);
            if (userToDelete == null)
            {
                return NotFound("User not found");
            }

            users.Remove(userToDelete);
            return Ok("Deleted user");
        }
    }
}

using AWSServerless.Repositories;
using AWSServerless.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AWSServerless.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.Get();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var user = await _userRepository.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserViewModel body)
        {
            var user = new User(body.Name, body.Idade);
            await _userRepository.Create(user);
            return CreatedAtAction(nameof(GetById), new { user.Id }, user);
        }
    }

    public class UserViewModel
    {
        public int Idade { get; set; }
        public string Name { get; set; }
    }
}

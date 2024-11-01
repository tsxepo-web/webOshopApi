using Microsoft.AspNetCore.Mvc;
using webOshop.Application.DTO.RequestDTO;
using webOshop.Application.DTO.ResponseDTO;
using webOshop.Domain.Entities;
using webOshop.Domain.Interfaces;

namespace webOshop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            var response = new UserResponse(
                Id: user.Id!,
                Username: user.Username!,
                Email: user.Email!,
                Address: user.Address!
            );
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest userRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new User
            {
                Username = userRequest.Username,
                Email = userRequest.Email,
                PasswordHash = userRequest.PasswordHash,
                Address = userRequest.Address
            };
            await _userRepository.AddUserAsync(user);

            var response = new UserResponse(
                Id: user.Id!,
                Username: userRequest.Username,
                Email: userRequest.Email,
                Address: userRequest.Address
            );
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(string id, [FromBody] UpdateUserRequest userRequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var existingUser = await _userRepository.GetUserByIdAsync(id);
            if (existingUser == null) return NotFound();

            existingUser.Username = userRequest.Username;
            existingUser.Email = userRequest.Email;
            existingUser.PasswordHash = userRequest.PasswordHash;
            existingUser.Address = userRequest.Address;

            await _userRepository.UpdateUserAsync(existingUser);

            var response = new UserResponse(
                Id: existingUser.Id!,
                Username: existingUser.Username,
                Email: existingUser.Email,
                Address: existingUser.Address
            );
            return Ok(response);
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for handling user authentication.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase {

    private readonly IUserService _userService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthController"/> class.
    /// </summary>
    /// <param name="userService">User service instance.</param>
    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="registerModel">User data transfer object.</param>
    /// <returns>A newly created user.</returns>
    [Authorize(Roles = "User")]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel registerModel) {
        var result = await _userService.RegisterAsync(registerModel);

        if(!result.Success){
            return BadRequest(new ApiResponse<object>(null, new List<string> { result.ErrorMessage} ));
        }   
        return CreatedAtAction(nameof(Register), new ApiResponse<object>(result.Result));
        //return Ok(result.Result);
    }

    /// <summary>
    /// Authenticates a user and generates a JWT token.
    /// </summary>
    /// <param name="loginModel">Login data transfer object.</param>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel){
        var result = await _userService.LoginAsync(loginModel);

        if(!result.Success) {
           return Unauthorized(new ApiResponse<object>(null, new List<string> { result.ErrorMessage })); 
        }

        return Ok(new ApiResponse<object>(new { Token = result.Result }));
        //return Ok(new { Token = result.Result });
    }
}
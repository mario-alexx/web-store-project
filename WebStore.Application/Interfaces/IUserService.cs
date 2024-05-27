/// <summary>
/// Service interface for user-related operations such as registration and login.
/// </summary>
public interface IUserService{
    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="userDto">User data transfer object</param>
    /// <returns>Task representing the asynchronous operation</returns>
    Task RegisterAsync(UserRequestModel userDto);

    /// <summary>
    /// Logs in a user.
    /// </summary>
    /// <param name="loginDto">Login data transfer object</param>
    /// <returns>Task representing the asynchronous operation, containing a JWT token if successful</returns>
    Task<string> LoginAsync(LoginModel loginDto);
}
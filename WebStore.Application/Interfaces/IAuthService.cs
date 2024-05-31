/// <summary>
/// Service interface for user-related operations such as registration and login.
/// </summary>
public interface IAuthService{
    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="registerModel">User data transfer object</param>
    /// <returns>Task representing the asynchronous operation</returns>
    Task<OperationResult<RegisterModel>> RegisterAsync(RegisterModel registerModel);

    /// <summary>
    /// Logs in a user.
    /// </summary>
    /// <param name="loginModel">Login data transfer object</param>
    /// <returns>Task representing the asynchronous operation, containing a JWT token if successful</returns>
    Task<OperationResult<string>> LoginAsync(LoginModel loginModel);
}
using System.Text;
using AutoMapper;
using XSystem.Security.Cryptography;
/// <summary>
/// Service implementation for user-related operations such as registration, login, and profile update.
/// </summary>
public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserService"/> class.
    /// </summary>
    /// <param name="unitOfWork">Unit of Work.</param>
    /// <param name="mapper">AutoMapper instance.</param>
    /// <param name="tokenService">Token service instance.</param>
    public UserService(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _tokenService = tokenService;
    }

    /// <inheritdoc />
    public async Task<OperationResult<string>> LoginAsync(LoginModel loginModel)
    {
        var user = await _unitOfWork.Users.GetUserByEmailAsync(loginModel.Email);
        if(user == null || !VerifyPassword(loginModel.Password,user.Password)){
            
            return OperationResult<string>.FailureResult("Invalid credentials");
        }
        var token = _tokenService.GenerateToken(user);
        return OperationResult<string>.SuccessResult(token);
    }

    /// <inheritdoc />
    public async Task<OperationResult<RegisterModel>> RegisterAsync(RegisterModel registerModel)
    {
        var result = await _unitOfWork.Users.EmailExistAsync(registerModel.Email);
        if(result){
            return OperationResult<RegisterModel>.FailureResult("Email already exist");
        }

        var user = _mapper.Map<User>(registerModel);
        user.Password = HashPassword(registerModel.Password);
        user.Role = UserRole.User;
        user.CreatedAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;
        
        _unitOfWork.Users.Insert(user);
        await _unitOfWork.SaveChangesAsync();

        var registeredUserModel = _mapper.Map<RegisterModel>(user);
        return OperationResult<RegisterModel>.SuccessResult(registeredUserModel);
    }

    /// <inheritdoc />
    public Task<OperationResult<UserRequestModel>> UpdateProfileAsync(UserRequestModel userRequestModel)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Encrypts the given password using MD5 hashing algorithm.
    /// </summary>
    /// <param name="password">The password to encrypt.</param>
    /// <returns>The hashed password.</returns>
    private string HashPassword(string password) {

        MD5CryptoServiceProvider x = new();
        byte[] data = Encoding.UTF8.GetBytes(password);
        data = x.ComputeHash(data);
        string response = "";
        for (int i = 0; i < data.Length; i++)
            response += data[i].ToString("x2".ToLower());

        return response;
    }

    /// <summary>
    /// Verifies the password by comparing the hash of the input password with the stored hash.
    /// </summary>
    /// <param name="inputPassword">The input password.</param>
    /// <param name="storedHash">The stored hash.</param>
    /// <returns>True if the passwords match, otherwise false.</returns>
    private bool VerifyPassword(string inputPassword, string storedHash){
        var hashInput = HashPassword(inputPassword);
        return hashInput == storedHash;
    }
}
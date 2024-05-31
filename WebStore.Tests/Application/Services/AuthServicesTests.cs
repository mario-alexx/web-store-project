using AutoMapper;
using Moq;

public class AuthServiceTests {
    private readonly IAuthService _authService;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<ITokenService> _tokenServiceMock;

    public AuthServiceTests() {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _userRepositoryMock = new Mock<IUserRepository>();
        _mapperMock = new Mock<IMapper>();
        _tokenServiceMock = new Mock<ITokenService>();

        //_unitOfWorkMock.Setup(uow => uow.).Returns(_userRepositoryMock.Object);

        _authService = new AuthService(_unitOfWorkMock.Object, _mapperMock.Object, _tokenServiceMock.Object);
    }

    [Fact]
    public async Task RegisterUser_ShouldReturnSuccess_WhenUserIsValid() {
        
        // Arrange
        var registerModel = new RegisterModel(UserName: "testUser", Email: "test@example.com", Password: "Test@1234");

        _userRepositoryMock.Setup(repo => repo.GetUserByEmailAsync(It.IsAny<string>())).ReturnsAsync((User)null);
        _tokenServiceMock.Setup(ph => ph.GenerateToken(It.IsAny<User>())).Returns("hashedPassword");

        // Act
        var result = await _authService.RegisterAsync(registerModel);

        // Assert
        Assert.True(result.Success);
        _userRepositoryMock.Verify(repo => repo.Insert(It.IsAny<User>()), Times.Once);
        _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task RegisterUser_ShouldFail_WhenEmailAlreadyExists()
    {
        // Arrange
        var registerModel = new RegisterModel(UserName: "testUser", Email: "test@example.com", Password: "Test@1234");
        
        var existingUser = new User { Email = "test@example.com" };
        _userRepositoryMock.Setup(repo => repo.GetUserByEmailAsync(It.IsAny<string>())).ReturnsAsync(existingUser);

        // Act
        var result = await _authService.RegisterAsync(registerModel);

        // Assert
        Assert.False(result.Success);
        Assert.Equal("Email already exists", result.ErrorMessage);
        _userRepositoryMock.Verify(repo => repo.Insert(It.IsAny<User>()), Times.Never);
        _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(CancellationToken.None), Times.Never);

    }
}
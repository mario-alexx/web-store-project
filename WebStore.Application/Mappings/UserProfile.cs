using AutoMapper;

/// <summary>
/// Represents a profile class for AutoMapper configuration related to user data.
/// </summary>
public class UserProfile : Profile {
    /// <summary>
    /// Initializes a new instance of the <see cref="UserProfile"/> class.
    /// </summary>
    public UserProfile() {
        // Creates two-way mappings between classes.
        CreateMap<User, LoginModel>().ReverseMap();
        CreateMap<User, RegisterModel>().ReverseMap();
        CreateMap<User, UserRequestModel>().ReverseMap();
    }
}
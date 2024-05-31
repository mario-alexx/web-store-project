/// <summary>
/// Configuration settings for JWT.
/// </summary>
public class JwtSettings {
    /// <summary>
    /// Gets or sets the secret key for JWT signing.
    /// </summary>
    public string Secret { get; set; } = null!;
    /// <summary>
    /// Gets or sets the token expiration time in days.
    /// </summary>
    public int ExpirationInDays { get; set; }
    /// <summary>
    /// Gets or sets the issuer of the JWT.
    /// </summary>
    public string Issuer { get; set; } = null!;
    /// <summary>
    /// Gets or sets the audience for the JWT.
    /// </summary>
    public string Audience { get; set; } = null!;

}
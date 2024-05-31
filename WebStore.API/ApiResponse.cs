/// <summary>
/// Represents a generic ApiResponse class for returning structured responses from APIs.
/// </summary>
/// <typeparam name="T">The type of data the response contains.</typeparam>
public class ApiResponse<T> {
    /// <summary>
    /// Gets or sets the status of the response, indicating success or error.
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets the data associated with the response.
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// Gets or sets a list of error messages, if any, associated with the response.
    /// </summary>
    public List<string> Errors { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiResponse{T}"/> class.
    /// </summary>
    /// <param name="data">The data to include in the response.</param>
    /// <param name="errors">An optional list of error messages (defaults to null).</param>
    public ApiResponse(T data, List<string> errors = null) {
        Status = errors == null ? "success" : "error";
        Data = data;
        Errors = errors;
    }
}



    
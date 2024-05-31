/// <summary>
/// Represents the result of an operation, with a success flag and an optional error message.
/// </summary>
public class OperationResult<T> {
    /// <summary>
    /// Gets or sets a value indicating whether the operation was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets an optional error message.
    /// </summary>
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// Gets or sets the result of the operation.
    /// </summary>
    public T ? Result { get; set; }

    /// <summary>
    /// Creates a successful operation result.
    /// </summary>
    /// <param name="result">The result of the operation.</param>
    /// <returns>A successful operation result.</returns>
    public static OperationResult<T> SuccessResult(T result)
    {
        return new OperationResult<T>
        {
            Success = true,
            Result = result
        };
    }

    /// <summary>
    /// Creates a failed operation result.
    /// </summary>
    /// <param name="errorMessage">The error message.</param>
    /// <returns>A failed operation result.</returns>
    public static OperationResult<T> FailureResult(string errorMessage)
    {
        return new OperationResult<T>
        {
            Success = false,
            ErrorMessage = errorMessage
        };
    }
}
namespace CleanArch.Domain.Shared;

public class Result
{
    public bool IsFailure { get; set; }
    public bool IsSuccess { get; set; }
    public string? Error { get; set; }
}


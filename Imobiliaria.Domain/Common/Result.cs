namespace Imobiliaria.Domain.Common;
public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    public static Result Success() => new(true, Error.None);
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
    public static Result<TValue> Created<TValue>(string createdLocation, TValue value) => new(value, true, Error.None, createdLocation);
    public static Result Failure(Error error) => new(false, error);
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
}

public class Result<TValue> : Result
{
    private readonly TValue? _value;
    public string? CreatedLocation { get; }
    public bool IsFailureOrNull => !IsSuccess || _value == null;

    public bool IsCreated => !string.IsNullOrWhiteSpace(CreatedLocation);

    protected internal Result(TValue? value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        _value = value;
    }
    protected internal Result(TValue? value, bool isSuccess, Error error, string createdLocation) : base(isSuccess, error)
    {
        _value = value;
        CreatedLocation = createdLocation;
    }

    public TValue Value => IsSuccess ? _value! : throw new InvalidOperationException("The value of a failure result can't be accessed.");
}
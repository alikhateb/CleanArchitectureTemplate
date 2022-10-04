using Domain.Primitives;

namespace Domain.ValueObjects;

public sealed class FirstName : ValueObject
{
    public const int MaxLength = 50;

    private FirstName(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static FirstName Create(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName)) throw new Exception("you must enter value for first name");

        if (firstName.Length > MaxLength) throw new Exception("first name should be equal 50 character or less");

        return new FirstName(firstName);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
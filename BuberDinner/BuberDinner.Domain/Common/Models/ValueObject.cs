namespace BuberDinner.Domain.Common.Models;


public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetEqualityComponents();
    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        var valueObject = (ValueObject)obj;

        return GetEqualityComponents()
                    .SequenceEqual(valueObject.GetEqualityComponents());
    }

    public static bool operator ==(ValueObject left, ValueObject right)
    {
        return Equals(left, right);
    }
    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !Equals(left, right);
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
                .Select(x => x?.GetHashCode() ?? 0)
                .Aggregate((x, y) => x ^ y);
    }

    public bool Equals(ValueObject? other)
    {
        return Equals((object?)other);
    }
}
// public class Price : ValueObject
// {
//     public decimal Amout { get; private set; }
//     public string Currency { get; private set; }
//     public Price(decimal amout, string currency)
//     {
//         Amout = amout;
//         Currency = currency;
//     }

//     public override IEnumerable<object> GetEqualityComponents()
//     {
//         yield return Amout;
//         yield return Currency;
//     }
// }
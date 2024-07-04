using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject 
{
    public double Value { get; private set; }
    public int NumRatings { get; private set; }
    private AverageRating(double value, int numRatings)
    {
        Value = value;
        NumRatings = numRatings;
    }
    public static AverageRating CreateNew(double rating = 0, int numRatings = 0)
    {
        return new(rating, numRatings);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return NumRatings;
    }

}
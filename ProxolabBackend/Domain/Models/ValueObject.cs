namespace ProxolabBackend.Domain.Models;

public abstract class ValueObject : IEquatable<ValueObject> {
    public abstract IEnumerable<Object> GetEqualityComponents();

    public override Boolean Equals(Object? @object) {
        if(@object is null || @object.GetType() != GetType())
            return default;


        ValueObject? valueObject = @object as ValueObject;

        return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }

    public static Boolean operator ==(ValueObject left, ValueObject right) => Equals(left, right);
    public static Boolean operator !=(ValueObject left, ValueObject right) => Equals(left, right) is false;
    public override Int32 GetHashCode() {
        return GetEqualityComponents()
                                            .Select(x => x?.GetHashCode() ?? 0)
                                            .Aggregate((x, y) => x ^ y);
    }

    public Boolean Equals(ValueObject? other) {
        return Equals((Object?)other);
    }
}

public class Price : ValueObject {
    public Decimal Amount { get; private set; }
    public String Currency { get; private set; }

    public Price(Decimal amount, String currency) {
        Amount = amount;
        Currency = currency;
    }

    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Amount;
        yield return Currency;
    }
}
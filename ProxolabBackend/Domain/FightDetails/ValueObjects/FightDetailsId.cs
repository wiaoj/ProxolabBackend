using ProxolabBackend.Domain.Models;

namespace ProxolabBackend.Domain.FightDetails.ValueObjects;

public sealed class FightDetailsId : ValueObject {
    public Guid Value { get; }
    private FightDetailsId(Guid value) { Value = value; }
    public static FightDetailsId CreateUnique => new(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents() {
        yield return Value;
    }
}
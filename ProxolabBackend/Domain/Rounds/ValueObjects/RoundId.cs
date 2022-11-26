using ProxolabBackend.Domain.Models;

namespace ProxolabBackend.Domain.Rounds.ValueObjects;

public sealed class RoundId : ValueObject {
    public Guid Value { get; }
    private RoundId(Guid value) { Value = value; }
    public static RoundId CreateUnique => new(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents() {
        yield return Value;
    }
}
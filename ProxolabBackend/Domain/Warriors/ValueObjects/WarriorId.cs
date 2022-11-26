using ProxolabBackend.Domain.Models;

namespace ProxolabBackend.Domain.Warriors.ValueObjects;

public sealed class WarriorId : ValueObject {
    public Guid Value { get; }
    private WarriorId(Guid value) { Value = value; }
    public static WarriorId CreateUnique => new(Guid.NewGuid());
    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Value;
    }
}
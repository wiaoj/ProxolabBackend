using ProxolabBackend.Domain.Models;
using ProxolabBackend.Domain.Warriors.ValueObjects;

namespace ProxolabBackend.Domain.User.ValueObjects;

public class UserId : ValueObject {
    public Guid Value { get; set; }
    private UserId(Guid value) { Value = value; }
    public static UserId CreateUnique => new(Guid.NewGuid());
    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Value;
    }
}

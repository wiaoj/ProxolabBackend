namespace ProxolabBackend.Domain.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : notnull {
    public TId Id { get; protected set; }

    protected Entity(TId id) {
        Id = id;
    }

    public override Boolean Equals(Object? @object) {
        return @object is Entity<TId> entity && Id.Equals(entity.Id);
    }

    public Boolean Equals(Entity<TId>? other) {
        return Equals((Object?)other);
    }

    public static Boolean operator ==(Entity<TId> left, Entity<TId> right) => Equals(left, right);
    public static Boolean operator !=(Entity<TId> left, Entity<TId> right) => Equals(left, right) is false;

    public override Int32 GetHashCode() {
        return Id.GetHashCode();
    }
}
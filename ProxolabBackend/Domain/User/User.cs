using ProxolabBackend.Domain.Models;
using ProxolabBackend.Domain.User.ValueObjects;

namespace ProxolabBackend.Domain.User;

public class User : AggregateRoot<UserId> {
    public User(UserId id) : base(id) { }

    public static String APIKEY { get; set; }

    public static User Create(UserId id) {
        return new(id);
    }
}
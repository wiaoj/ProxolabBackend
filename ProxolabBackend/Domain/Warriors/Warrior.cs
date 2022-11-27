using ProxolabBackend.Domain.FightDetails;
using ProxolabBackend.Domain.Models;
using ProxolabBackend.Domain.Warriors.ValueObjects;
using System.Security.Cryptography;
using System.Threading;

namespace ProxolabBackend.Domain.Warriors;

public class Warrior : AggregateRoot<WarriorId> {
    public String APIKEY { get; set; }
    public String Name { get; set; }
    public Int32 Health { get; set; }
    public Attack Attack { get; set; }
    public Defance Defance { get; set; }
    public ICollection<FightDetail> FightDetails { get; set; }
    private Warrior(WarriorId id, String name, Byte health, Attack attack, Defance defance) : base(id) {
        Name = name;
        Health = health;
        Attack = attack;
        Defance = defance;
        FightDetails = new HashSet<FightDetail>();


        AddAPIKey();
    }
    private const Byte HealthMinValue = 80;
    private const Byte HealthMaxValue = 100;

    public static Warrior Create(String name, Byte health, Attack attack, Defance defance) {
        return health is < HealthMinValue or > HealthMaxValue
            ? throw new Exception($"Sağlık değeri {HealthMinValue} ile {HealthMaxValue} arasında olmalıdır.")
            : (new(WarriorId.CreateUnique, name, health, attack, defance));
    }

    public Task AddFightDetails(FightDetail fightDetails) {
        FightDetails.Add(fightDetails);
        return Task.CompletedTask;
    }

    public void DecreaseHealth(Byte count) {
        Health -= count;
    }

    public void HealthWarrior(Int32 health) {
        Health = health;
    }

    private void AddAPIKey() {
        var key = new byte[new Random().Next(64, 128)];
        using var generator = RandomNumberGenerator.Create();
        generator.GetBytes(key);
        APIKEY = Convert.ToBase64String(key);
    }
}
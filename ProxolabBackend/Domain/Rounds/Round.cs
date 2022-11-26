using ProxolabBackend.Domain.Models;
using ProxolabBackend.Domain.Rounds.ValueObjects;
using ProxolabBackend.Domain.Warriors;
using ProxolabBackend.Domain.Warriors.ValueObjects;

namespace ProxolabBackend.Domain.Rounds;

public sealed class Round : AggregateRoot<RoundId> {
    public DateTime RoundStartedTime { get; set; }
    public DateTime RoundCompletedTime { get; set; }
    public TimeSpan RoundTime { get; set; }
    private Round(RoundId id, int roundNumber, Warrior attacker, Warrior defancer) : base(id) {
        RoundStartedTime = DateTime.Now;
        RoundNumber = roundNumber;
        AttackedWarriorId = attacker.Id;
        DefancedWarriorId = defancer.Id;

        AttackerHealth = attacker.Health;
        DefancerHealth = defancer.Health;

        Random random = new();
        WarriorAttackType = random.Next(0, 100) > 50 ? AttackType.Long : AttackType.Short;

        AttackQuantity = WarriorAttackType is AttackType.Long ? attacker.Attack.Long : attacker.Attack.Short;



        WarriorDefanceType = random.Next(0, 100) > 50 ? DefanceType.Long : DefanceType.Short;

        DefanceQuantity = WarriorDefanceType is DefanceType.Long ? defancer.Defance.Long : defancer.Defance.Short;

        byte takenDamage = Convert.ToByte(((byte)WarriorAttackType == (byte)WarriorDefanceType)
                                    ? AttackQuantity - DefanceQuantity
                                    : AttackQuantity);

        defancer.DecreaseHealth(takenDamage);

        TakenDamage = takenDamage;

        RoundFinishedDefancerHealth = defancer.Health;

        RoundCompletedTime = DateTime.Now;
        RoundTime = RoundCompletedTime - RoundStartedTime;
    }

    public int RoundNumber { get; set; }

    public WarriorId AttackedWarriorId { get; set; }
    public int AttackQuantity { get; set; }
    public AttackType WarriorAttackType { get; set; }
    public int AttackerHealth { get; set; }

    public WarriorId DefancedWarriorId { get; set; }
    public int DefanceQuantity { get; set; }
    public DefanceType WarriorDefanceType { get; set; }
    public int DefancerHealth { get; set; }
    public int RoundFinishedDefancerHealth { get; set; }
    public int TakenDamage { get; set; }

    public static Round Create(int roundNumber, Warrior attackedWarrior, Warrior defancedWarrior) {
        return new(RoundId.CreateUnique, roundNumber, attackedWarrior, defancedWarrior);
    }

    public enum AttackType {
        Short,
        Long
    }
    public enum DefanceType {
        Short,
        Long
    }
}

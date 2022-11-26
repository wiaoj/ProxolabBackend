using ProxolabBackend.Domain.FightDetails;
using ProxolabBackend.Domain.Warriors;

namespace ProxolabBackend.Contracts;

public record class CreateWarriorRequest(String Name, Byte Health);
public record class CreateWarriorResponse(Warrior Warrior);

public record class DeleteWarriorRequest(Guid Id);
public record class DeleteWarriorResponse(Warrior Warrior);
public record class FightWarriorRequest(Guid Id);
public record class FightWarriorResponse(FightDetail FightDetail);
using ProxolabBackend.Domain.FightDetails.ValueObjects;
using ProxolabBackend.Domain.Models;
using ProxolabBackend.Domain.Rounds;
using ProxolabBackend.Domain.Warriors.ValueObjects;

namespace ProxolabBackend.Domain.FightDetails;

public sealed class FightDetail : AggregateRoot<FightDetailsId> {
    private FightDetail(FightDetailsId id, WarriorId matchedWarriorId, WarriorId startedWarriorId) : base(id) {
        MatchedWarriorId = matchedWarriorId;
        StartedWarriorId = startedWarriorId;
        Rounds = new HashSet<Round>();
        StartedTime = DateTime.Now;
    }

    public WarriorId MatchedWarriorId { get; set; }
    public WarriorId StartedWarriorId { get; set; }
    public DateTime StartedTime { get; set; }
    public DateTime FinishedTime { get; set; }
    public TimeSpan FightTime { get; set; }
    public ICollection<Round> Rounds { get; set; }

    public WarriorId WinnerWarrior { get; set; }
    public static FightDetail Create(WarriorId matchedWarriorId, WarriorId startedWarriorId) {
        return new(FightDetailsId.CreateUnique, matchedWarriorId, startedWarriorId);
    }

    public Task AddRound(Round round) {
        Rounds.Add(round);
        return Task.CompletedTask;
    }

    public Task AddWinner(WarriorId warriorId) {
        WinnerWarrior = warriorId;
        FinishedTime = DateTime.Now;
        FightTime = FinishedTime - StartedTime;
        return Task.CompletedTask;
    }
}
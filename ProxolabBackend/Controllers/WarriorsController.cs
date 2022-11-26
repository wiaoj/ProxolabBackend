using Microsoft.AspNetCore.Mvc;
using ProxolabBackend.Contracts;
using ProxolabBackend.Domain.FightDetails;
using ProxolabBackend.Domain.Rounds;
using ProxolabBackend.Domain.Warriors;
using ProxolabBackend.Domain.Warriors.ValueObjects;
using ProxolabBackend.Middlewares;
using System.Security.Cryptography;

namespace ProxolabBackend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class WarriorsController : ControllerBase {
    public static readonly List<Warrior> _warriors = new();

    public WarriorsController() { }

    [HttpPost("[action]")]
    public IActionResult CreateWarrior([FromBody] CreateWarriorRequest request) {
        Random random = new();

        Byte shortAttackRangeMinValue = 14;
        Byte shortAttackRangeMaxValue = 20;
        Byte shortAttackRangeValue = (Byte)random.Next(shortAttackRangeMinValue, shortAttackRangeMaxValue);

        Byte longAttackRangeMinValue = 8;
        Byte longAttackRangeMaxValue = 14;
        Byte longAttackRangeValue = (Byte)random.Next(longAttackRangeMinValue, longAttackRangeMaxValue);

        Byte shortDefanceRangeMinValue = 8;
        Byte shortDefanceRangeMaxValue = 14;
        Byte shortDefanceRangeValue = (Byte)random.Next(shortDefanceRangeMinValue, shortDefanceRangeMaxValue);

        Byte longDefanceRangeMinValue = 4;
        Byte longDefanceRangeMaxValue = 8;
        Byte longDefanceRangeValue = (Byte)random.Next(longDefanceRangeMinValue, longDefanceRangeMaxValue);

        Warrior warrior = Warrior.Create(request.Name, request.Health, Attack.Create(shortAttackRangeValue, longAttackRangeValue), Defance.Create(shortDefanceRangeValue, longDefanceRangeValue));

        Boolean isWarriorNameAlreadyTaken = _warriors.Any(x => x.Name.Equals(request.Name, StringComparison.OrdinalIgnoreCase));

        if(isWarriorNameAlreadyTaken)
            return BadRequest("Savaþçý mevcut");

        var key = new byte[32];
        using var generator = RandomNumberGenerator.Create();
        generator.GetBytes(key);
        String apiKey = Convert.ToBase64String(key);
        warrior.AddAPIKey(apiKey);


        _warriors.Add(warrior);
        CreateWarriorResponse response = new(warrior);
        return Ok(response);
    }

    [HttpDelete("[action]/{request.Id}")]
    public IActionResult DeleteWarrior([FromRoute] DeleteWarriorRequest request) {
        var warrior = _warriors.FirstOrDefault(x => x.Id.Value.Equals(request.Id));
        if(warrior is null)
            return BadRequest($"{request.Id}'ye sahip bir savaþçý bulunamadý.");

        _warriors.Remove(warrior);
        DeleteWarriorResponse response = new(warrior);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public IActionResult GenerateRandomWarriors(Byte? times = 15) {
        List<Warrior> addedWarriors = new();
        Random random = new();

        Byte shortAttackRangeMinValue = 14;
        Byte shortAttackRangeMaxValue = 20;

        Byte longAttackRangeMinValue = 8;
        Byte longAttackRangeMaxValue = 14;

        Byte shortDefanceRangeMinValue = 8;
        Byte shortDefanceRangeMaxValue = 14;

        Byte longDefanceRangeMinValue = 4;
        Byte longDefanceRangeMaxValue = 8;

        while(times-- > 0) {
            Byte shortAttackRangeValue = (Byte)random.Next(shortAttackRangeMinValue, shortAttackRangeMaxValue);
            Byte longAttackRangeValue = (Byte)random.Next(longAttackRangeMinValue, longAttackRangeMaxValue);
            Byte shortDefanceRangeValue = (Byte)random.Next(shortDefanceRangeMinValue, shortDefanceRangeMaxValue);
            Byte longDefanceRangeValue = (Byte)random.Next(longDefanceRangeMinValue, longDefanceRangeMaxValue);

            Warrior warrior = Warrior.Create($"Savaþçý {Guid.NewGuid()}", (Byte)random.Next(80, 100), Attack.Create(shortAttackRangeValue, longAttackRangeValue), Defance.Create(shortDefanceRangeValue, longDefanceRangeValue));
            _warriors.Add(warrior);
            addedWarriors.Add(warrior);
        }
        return Ok(addedWarriors);
    }

    [HttpGet("[action]")]
    public IActionResult GetAllWarriors() {
        return Ok(_warriors);
    }


    [HttpGet("[action]/{request.Id}")]
    public IActionResult FightWarrior([FromRoute] FightWarriorRequest request) {
        Warrior? requestedWarrior = _warriors.FirstOrDefault(x => x.Id.Value.Equals(request.Id));

        if(requestedWarrior is null)
            return BadRequest(new {
                request.Id,
                Message = $"{request.Id} Id'ye sahip bir savaþçý bulunamadý."
            });

        Random random = new();
        Warrior selectedWarrior = _warriors[random.Next(0, _warriors.Count)];
        if(selectedWarrior.Id.Value.Equals(request.Id))
            return Ok("Þanslýsýn kurada kendini çektiðin için bu turda kimseyle savaþmayacaksýn :)");


        Int32 requestedWarriorChance = random.Next(0, 100);

        var attacker = requestedWarriorChance > 50 ? requestedWarrior : selectedWarrior;
        var defancer = requestedWarriorChance < 50 ? requestedWarrior : selectedWarrior;


        var attackerWarriorHealth = attacker.Health;
        var defancerWarriorHealth = defancer.Health;


        FightDetail attackerWarriorFightDetails = FightDetail.Create(defancer.Id, attacker.Id);
        FightDetail defancerWarriorFightDetails = FightDetail.Create(attacker.Id, defancer.Id);

        //var fightDetailId = attackerWarriorFightDetails.Id;


        for(int roundNumber = 1; ; roundNumber++) {
            if(attacker.Health < 1 || defancer.Health < 1)
                break;

            Round round;

            if(roundNumber.Equals(1)) {
                round = Round.Create(roundNumber, attacker, defancer);
            } else {

                var selectAttackedWarrior = attackerWarriorFightDetails.Rounds
                    .Where(x => x.RoundNumber.Equals(roundNumber - 1))
                    .Any(x => x.AttackedWarriorId.Equals(attacker.Id));

                round = selectAttackedWarrior
                    ? Round.Create(roundNumber, defancer, attacker)
                    : Round.Create(roundNumber, attacker, defancer);
            }


            attackerWarriorFightDetails.AddRound(round);
            defancerWarriorFightDetails.AddRound(round);
        }

        var winner = attacker.Health > defancer.Health ? attacker.Id : defancer.Id;
        attackerWarriorFightDetails.AddWinner(winner);
        defancerWarriorFightDetails.AddWinner(winner);

        attacker.AddFightDetails(attackerWarriorFightDetails);
        defancer.AddFightDetails(defancerWarriorFightDetails);

        attacker.HealthWarrior(attackerWarriorHealth);
        defancer.HealthWarrior(defancerWarriorHealth);

        FightDetail fightDetail = requestedWarrior.FightDetails.Any(x =>
                                    x.Id.Equals(attackerWarriorFightDetails.Id))
                            ? requestedWarrior.FightDetails.FirstOrDefault(x =>
                                    x.Id.Equals(attackerWarriorFightDetails.Id))
                            : requestedWarrior.FightDetails.FirstOrDefault(x =>
                                    x.Id.Equals(defancerWarriorFightDetails.Id));

        FightWarriorResponse response = new(fightDetail);
        return Ok(response);
    }
}

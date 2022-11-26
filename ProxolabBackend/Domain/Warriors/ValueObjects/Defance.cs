using ProxolabBackend.Domain.Models;

namespace ProxolabBackend.Domain.Warriors.ValueObjects;

public class Defance : ValueObject {
    private const byte ShortRangeMinValue = 8;
    private const byte ShortRangeMaxValue = 14;

    private const byte LongRangeMinValue = 4;
    private const byte LongRangeMaxValue = 8;
    public byte Short { get; set; }
    public byte Long { get; set; }

    private Defance(byte @short, byte @long) {
        Short = @short;
        Long = @long;
    }

    public static Defance Create(byte @short, byte @long) {
        return @short is < ShortRangeMinValue or > ShortRangeMaxValue
            ? throw new Exception($"Kısa mesafe defansı {ShortRangeMinValue} ile {ShortRangeMaxValue} arasında olmalıdır.")
            : @long is < LongRangeMinValue or > LongRangeMaxValue
            ? throw new Exception($"Uzun mesafe defansı {LongRangeMinValue} ile {LongRangeMaxValue} arasında olmalıdır.")
            : (new(@short, @long));
    }

    public byte SelectLongDefanceChance() {
        return SelectLongDefanceChance(50);
    }

    public byte SelectLongDefanceChance(byte chance) {
        Random random = new();
        return random.Next(0, 101) > chance ? Long : Short;
    }

    public override IEnumerable<object> GetEqualityComponents() {
        yield return Short;
        yield return Long;
    }
}

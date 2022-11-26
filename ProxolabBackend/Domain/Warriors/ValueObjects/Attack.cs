using ProxolabBackend.Domain.Models;

namespace ProxolabBackend.Domain.Warriors.ValueObjects;

public class Attack : ValueObject {
    private const byte ShortRangeMinValue = 14;
    private const byte ShortRangeMaxValue = 20;

    private const byte LongRangeMinValue = 8;
    private const byte LongRangeMaxValue = 14;
    public byte Short { get; set; }
    public byte Long { get; set; }

    private Attack(byte @short, byte @long) {
        Short = @short;
        Long = @long;
    }

    public static Attack Create(byte @short, byte @long) {
        return @short is < ShortRangeMinValue or > ShortRangeMaxValue
            ? throw new Exception($"Kısa mesafeli saldırı {ShortRangeMinValue} ile {ShortRangeMaxValue} arasında olmalıdır.")
            : @long is < LongRangeMinValue or > LongRangeMaxValue
            ? throw new Exception($"Uzun mesafeli saldırı {LongRangeMinValue} ile {LongRangeMaxValue} arasında olmalıdır.")
            : (new(@short, @long));
    }

    public override IEnumerable<object> GetEqualityComponents() {
        yield return Short;
        yield return Long;
    }
}
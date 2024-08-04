namespace AvonaleSimplificado.Domain.Common
{
    public record Money(double Value)
    {
        public static Money Sum(Money value1, Money value2)
        {
            return new Money(value1.Value + value2.Value);
        }

        public static Money Sub(Money value1, Money value2)
        {
            return new Money(value1.Value - value2.Value);
        }
    }
}

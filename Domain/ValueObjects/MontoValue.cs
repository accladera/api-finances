using SharedKernel.Core;

namespace Domain.ValueObjects
{
    public record MontoValue : ValueObject
    {
        public decimal Value { get; init; }
        public MontoValue(decimal value)
        {
            if (value < 0)
            {
                throw new BussinessRuleValidationException("El monto debe ser negativo.");
            }
            Value = value;
        }

        public static implicit operator decimal(MontoValue value)
        {
            return value.Value;
        }

        public static implicit operator MontoValue(decimal value)
        {
            return new MontoValue(value);
        }
    }
}

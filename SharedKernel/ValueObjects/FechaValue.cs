
using SharedKernel.Core;
using SharedKernel.Rules;

namespace SharedKernel.ValueObjects
{
    public record FechaValue : ValueObject 
    {
        public DateTime Date { get; init; }

        public FechaValue(DateTime date)
        {
            CheckRule(new NotNullRule(date));

            Date = date;
        }

        public static implicit operator DateTime(FechaValue value)
        {
            return value.Date;
        }

        public static implicit operator FechaValue(DateTime date)
        {
            return new FechaValue(date);
        }
    }
}

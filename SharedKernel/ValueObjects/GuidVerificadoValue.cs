using SharedKernel.Core;
using SharedKernel.Rules;
namespace SharedKernel.ValueObjects
{
    public record GuidVerificadoValue : ValueObject
    {
        public Guid Id { get; init; }

        public GuidVerificadoValue(Guid id)
        {
            CheckRule(new NotNullRule(id));
            Id = id;
        }

        public static implicit operator Guid(GuidVerificadoValue value)
        {
            return value.Id;
        }
        public static implicit operator GuidVerificadoValue(Guid id)
        {
            return new GuidVerificadoValue(id);
        }

    }
}

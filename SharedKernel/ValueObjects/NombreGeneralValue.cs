using SharedKernel.Core;
using SharedKernel.Rules;
namespace SharedKernel.ValueObjects
{
    public record NombreGeneralValue : ValueObject
    {
        public string Name { get; init; }

        public NombreGeneralValue(string name)
        {
            CheckRule(new StringNotNullOrEmptyRule(name));
            CheckRule(new StringLengthLimitRule(name, 50));
            Name = name;
        }

        public static implicit operator string(NombreGeneralValue value)
        {
            return value.Name;
        }

        public static implicit operator NombreGeneralValue(string name)
        {
            return new NombreGeneralValue(name);
        }
    }
}

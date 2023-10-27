using SharedKernel.Core;

namespace SharedKernel.Rules
{
    public class StringLengthLimitRule : IBussinessRule
    {
        public string Value { get; }
        public int LengthLimit { get; set; }

        public StringLengthLimitRule(string value, int lengthLimit)
        {
            LengthLimit = lengthLimit;
            Value = value;
        }

        public string Message => $"El texto no debe pasar de los {LengthLimit} caracteres.";

        public bool IsValid()
        {
            return Value.Length <= LengthLimit;
        }
    }
}
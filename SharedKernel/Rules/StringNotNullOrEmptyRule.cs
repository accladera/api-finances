using SharedKernel.Core;

namespace SharedKernel.Rules
{
    public class StringNotNullOrEmptyRule : IBussinessRule
    {
        private readonly string _value;

        public StringNotNullOrEmptyRule(string value)
        {
            _value = value;
        }

        public string Message => "El valor no puede estar vacío.";

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(_value);
        }
    }
}
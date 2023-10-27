using SharedKernel.Core;
using System.Text.RegularExpressions;

namespace SharedKernel.Rules
{
    public class StringOnlyLettersRule : IBussinessRule
    {
        public readonly string _value;
        public StringOnlyLettersRule(string value)
        {
            _value=value;

        }
        public string Message => "Value cannot contains numbers or special characters";
      

        public bool IsValid()
        {
            return Regex.IsMatch(_value, "\\d");
        }
    }
}

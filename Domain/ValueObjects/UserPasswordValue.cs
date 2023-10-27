using Domain.ValueObjects.Enum;
using SharedKernel.Core;
using SharedKernel.Rules;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public record UserPasswordValue: ValueObject
    {
        public string Password { get; init; }

        public UserPasswordValue(string password) {
            CheckRule(new StringNotNullOrEmptyRule(password));
            CheckRule(new StringLengthLimitRule(password, 25));
           
            PasswordScore score = CheckStrength(password);
            switch (score)
            {
                case PasswordScore.Blank:
                case PasswordScore.VeryWeak:
                case PasswordScore.Weak:

                    throw new BussinessRuleValidationException("La contraseña es muy débil.");
                case PasswordScore.Medium:
                case PasswordScore.Strong:
                case PasswordScore.VeryStrong:
                    Password = password;
                    break;
            }

        }


        public static implicit operator string(UserPasswordValue password)
        {
            return password.Password;
        }

        public static implicit operator UserPasswordValue(string password)
        {
            return new UserPasswordValue(password);
        }


        public  PasswordScore CheckStrength(string password)
        {
            int score =0;

            if (password.Length < 1)
                return PasswordScore.Blank;
            if (password.Length <= 4)
                return PasswordScore.VeryWeak;

            if (password.Length >= 5)
                score++;
            if (password.Length >= 6)
                score++;
            if (password.Length >= 8)
                score++;
            if (password.Length >= 10)
                score++;
            if (password.Length >= 12)
                score++;
            if (Regex.Match(password, @"/\d+/", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"/[a-z]/", RegexOptions.ECMAScript).Success &&
              Regex.Match(password, @"/[A-Z]/", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/", RegexOptions.ECMAScript).Success)
                score++;

            return (PasswordScore)score;
        }
    }
}

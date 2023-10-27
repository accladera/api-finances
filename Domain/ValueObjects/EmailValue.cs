using SharedKernel.Core;
using SharedKernel.Rules;

namespace Domain.ValueObjects
{
    public record EmailValue : ValueObject
    {

        public string Email { get; init; }

        public EmailValue(string email )
		{
            string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            CheckRule(new RegexRule(email,"email",pattern)) ;
            Email = email;
        }


        public static implicit operator string(EmailValue email)
        {
            return email.Email;
        }

        public static implicit operator EmailValue(string email)
        {
            return new EmailValue(email);
        }


    }
}

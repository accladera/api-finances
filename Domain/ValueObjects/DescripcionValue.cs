using SharedKernel.Core;
using SharedKernel.Rules;

namespace Domain.ValueObjects
{
    public record DescripcionValue : ValueObject
    {
      
            public string Descripcion { get; init; }

        public DescripcionValue(string descripcion)
        {
            CheckRule(new StringNotNullOrEmptyRule(descripcion));
            CheckRule(new StringLengthLimitRule(descripcion, 100));
            Descripcion = descripcion;
        }

        public static implicit operator string(DescripcionValue descripcion)
        {
            return descripcion.Descripcion;
        }

        public static implicit operator DescripcionValue(string descripcion)
        {
            return new DescripcionValue(descripcion);
        }
    }
}

using Domain.Model.Cuentas;

namespace Domain.Factories.Cuentas
{
    public interface ICuentaFactory
    {
        Cuenta Create(Guid usuarioId, string nombre, decimal saldo);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.UseCases.Query.Movimientos.mappers
{
    internal class EnumTipoMapper
    {
        public static int enumTipoMapper(string tipo)
        {
            if (tipo == "Egreso")
                return 1;
            else
                return 0;
        }
    }
}

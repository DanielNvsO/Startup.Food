using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Startup.Food.Repositorio.Entidade;

namespace Startup.Food.Repositorio.Interface
{
    public interface IPromocao
    {
        decimal Calcula(EntidadeLanche Lanches);
    }
}

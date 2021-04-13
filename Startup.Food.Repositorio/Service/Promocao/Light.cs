using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Startup.Food.Repositorio.Entidade;
using Startup.Food.Repositorio.Interface;

namespace Startup.Food.Repositorio.Service.Promocao
{
    public class Light : IPromocao
    {
        public decimal Calcula(EntidadeLanche Lanches)
        {
            try {
                bool Alface = false;
                bool Bacon = true;
            
                foreach(var ingre in Lanches.Ingredientes)
                {
                    if (ingre.Codigo == "Alface" && ingre.Quantidade > 0)
                        Alface = true;

                    if (ingre.Codigo == "Bacon" && ingre.Quantidade == 0)
                        Bacon = false;
                }

                if (Alface == true && Bacon == false)
                    return Lanches.Valor * decimal.Parse("0,9");
                else
                    return Lanches.Valor;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

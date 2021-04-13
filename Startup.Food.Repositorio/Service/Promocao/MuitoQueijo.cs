using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Startup.Food.Repositorio.Entidade;
using Startup.Food.Repositorio.Interface;

namespace Startup.Food.Repositorio.Service.Promocao
{
    public class MuitoQueijo :IPromocao
    {

        public decimal Calcula(EntidadeLanche Lanches)
        {
            try
            {
                int QuantidadeFixa = 3;
                int QuantidadeFixaPromocao = 2;

;               int QuantidadePromocao = 0;
                int QuantidadeReal = 0;
                decimal ValorDesconto = 0;
                decimal ValorIngrediente = 0;

                foreach (var ingre in Lanches.Ingredientes)
                {
                    if (ingre.Codigo == "Queijo")
                    {
                        if (ingre.Quantidade >= 3)
                        {
                            ValorIngrediente = ingre.Valor;
                            QuantidadePromocao = (ingre.Quantidade / QuantidadeFixa) * QuantidadeFixaPromocao;
                            QuantidadeReal = ingre.Quantidade;
                        }
                    }

                }

               ValorDesconto = (QuantidadeReal *  ValorIngrediente) -(QuantidadePromocao  * ValorIngrediente);

               return Lanches.Valor - ValorDesconto;


            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

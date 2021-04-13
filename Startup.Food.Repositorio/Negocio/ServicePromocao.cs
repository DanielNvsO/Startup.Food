using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Startup.Food.Repositorio.Entidade;
using Startup.Food.Repositorio.Service;
using Startup.Food.Repositorio.Interface;

namespace Startup.Food.Repositorio.Negocio
{
    public class ServicePromocao
    {
  

        public decimal Valor { get; set; }
        public bool PromocaoObtida { get; set; }
        public string NomePromocao { get; set; }

        public void CalcularPromocao(EntidadeLanche Lanche, IPromocao Promocao)
        {
            try
            { 
                if (PromocaoObtida == false) { 
                    Valor = Promocao.Calcula(Lanche);

                    if (Lanche.Valor != Valor)
                    {
                        PromocaoObtida = true;
                        NomePromocao = Promocao.GetType().Name;
                    }
                
                    Lanche.Valor = Valor;

                    
                }


            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

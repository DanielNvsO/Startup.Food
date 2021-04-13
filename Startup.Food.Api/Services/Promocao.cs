using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Startup.Food.Repositorio.Negocio;
using Startup.Food.Repositorio.Negocio.Promocao;
using Startup.Food.Repositorio.Entidade;
using Startup.Food.Repositorio.Interface;
using Newtonsoft.Json.Linq;

namespace Startup.Food.Api.Services
{
    public class Promocao
    {
        public JObject CalcularPromocao(EntidadeLanche Lanche) {

            try
            {
                IPromocao light = new Light();
                IPromocao muitaCarne = new MuitaCarne();
                IPromocao muitoQueijo = new MuitoQueijo();

                ServicePromocao promocao = new ServicePromocao();

                promocao.CalcularPromocao(Lanche, light);
                promocao.CalcularPromocao(Lanche, muitaCarne);
                promocao.CalcularPromocao(Lanche, muitoQueijo);

                JObject _return = new JObject();

                _return.Add("Valor", promocao.Valor);
                _return.Add("NomePromocao", promocao.NomePromocao);
                 
                return _return;
            }
            catch (Exception ex)
            {
                throw;
            }


        }
    }
}

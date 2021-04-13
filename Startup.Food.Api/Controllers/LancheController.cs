using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using Startup.Food.Repositorio.Entidade;
using Startup.Food.Repositorio.Repositorio;
using Startup.Food.Repositorio.Service;
using Startup.Food.Api.Services;
using Newtonsoft.Json.Linq;

namespace Startup.Food.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class LancheController : ControllerBase
    {
       [HttpPost]
       [Route("ConsultarLanches")]
       [Authorize]
        public ActionResult Lanches()
        {
            RepositorioLanche lanche = new RepositorioLanche();
            List<EntidadeLanche> _return;
            try
            {
                _return = lanche.ConsultarLanches();

                return Ok(_return);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                lanche = null;
                _return = null;
            }
        }

        [HttpPost]
        [Route("ConsultarIngredientes")]
        [Authorize]
        public ActionResult ConsultarIngrediente()
        {
            RepositorioLanche ingrediente = new RepositorioLanche();
            List<EntidadeIngrediente> _return;

            try
            {

                _return = ingrediente.ConsultarIngredientes();

                return Ok(_return);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                ingrediente = null;
                _return = null;
            }


        }

        [HttpPost]
        [Route("CalcularPromocao")]
        [Authorize]
        public ActionResult CalcularPromocao([FromBody] EntidadeLanche Lanche)
        {
            Promocao promo = new Promocao();
            JObject _return;

            try
            {
                _return = promo.CalcularPromocao(Lanche);

                return Ok(_return);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                promo = null;
                _return = null;
            }


        }

    }
}

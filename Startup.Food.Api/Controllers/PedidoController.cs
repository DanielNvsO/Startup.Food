using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Startup.Food.Repositorio.Entidade;
using Startup.Food.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Startup.Food.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        public IRepositorioPedido _IRepositorioPedido;
        public PedidoController(IRepositorioPedido RepositorioPedido)
        {
            this._IRepositorioPedido = RepositorioPedido;
        }

        [HttpPost]
        [Route("InsertPedido")]
        [Authorize]
        public ActionResult InsertPedido([FromBody] EntidadePedido Pedido)
        {
            bool _return;
            try
            {
                _return = _IRepositorioPedido.InsertPedido(Pedido);

                return Ok(_return);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

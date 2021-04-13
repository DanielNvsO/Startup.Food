using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Startup.Food.Repositorio.Entidade;

namespace Startup.Food.Repositorio.Builder
{
    public class BuilderPedido
    {
        private int _Id;
        private List<EntidadePedidoItem> _PedidoItem;
        private DateTime _DataPedido;
        private decimal _ValorPedido;
        private decimal _ValorDesconto;
        private decimal _ValorTotal;



        public EntidadePedido CriarPedido()
        {
            return new EntidadePedido(this._PedidoItem, this._DataPedido, this._ValorPedido, this._ValorDesconto, _ValorTotal);
        }
        
        public BuilderPedido PedidoItem(List<EntidadePedidoItem> PedidoItem)
        {
            this._PedidoItem = PedidoItem;

            return this;
        }
        public BuilderPedido ValorTotal(decimal ValorTotal)
        {
            this._ValorTotal = ValorTotal;

            return this;
        }
        public BuilderPedido ValorPedido(decimal ValorPedido)
        {
            this._ValorPedido = ValorPedido;

            return this;
        }
        public BuilderPedido ValorDesconto(decimal ValorDesconto)
        {
            this._ValorDesconto = ValorDesconto;

            return this;
        }
        public BuilderPedido DataPedido(DateTime DataPedido)
        {
            this._DataPedido = DataPedido;

            return this;
        }
       

    }
}

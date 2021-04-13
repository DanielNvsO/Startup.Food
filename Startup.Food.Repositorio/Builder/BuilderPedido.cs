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
        private int Id;
        private List<EntidadeLanche> _Lanches;
        private decimal _ValorTotal;
        private DateTime _DataPedido;
        private string _NomeCliente;

       
        public EntidadePedido CriarPedido()
        {
            return new EntidadePedido(this._Lanches, this._ValorTotal, this._DataPedido, this._NomeCliente);
        }
        

        public BuilderPedido Lanches(List<EntidadeLanche> Lanches)
        {
            this._Lanches = Lanches;

            return this;
        }
        public BuilderPedido ValorTotal(decimal ValorTotal)
        {
            this._ValorTotal = ValorTotal;

            return this;
        }
        public BuilderPedido DataPedido(DateTime DataPedido)
        {
            this._DataPedido = DataPedido;

            return this;
        }
        public BuilderPedido NomeCliente(string NomeCliente)
        {
            this._NomeCliente = NomeCliente;

            return this;
        }

    }
}

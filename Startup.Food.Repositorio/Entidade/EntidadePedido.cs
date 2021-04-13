using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup.Food.Repositorio.Entidade
{
    public class EntidadePedido
    {
        public int Id { get; set; }

        public List<EntidadeLanche> Lanches { get; private set; }

        public decimal ValorTotal { get; private set; }

        public DateTime DataPedido { get; private set; }

        public string NomeCliente { get; private set; }

       
        public EntidadePedido(List<EntidadeLanche> Lanches, 
                              decimal ValorTotal, 
                              DateTime DataPedido, 
                              string NomeCliente)
        {
            this.Lanches = Lanches;
            this.ValorTotal = ValorTotal;
            this.DataPedido = DataPedido;
            this.NomeCliente = NomeCliente;
            
        }
    }
}

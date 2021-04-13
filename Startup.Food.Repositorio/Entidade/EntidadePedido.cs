using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Startup.Food.Repositorio.Entidade
{
    [XmlRoot("Pedido")]
    public class EntidadePedido
    {
        [XmlElement("Id")]
        public int Id { get; set; }
        [XmlArray("PedidoItem")]
        [XmlArrayItem("EntidadePedidoItem")]
        public List<EntidadePedidoItem> PedidoItem { get; set; }
        [XmlElement("DataPedido")]
        public DateTime DataPedido { get;  set; }
        [XmlElement("ValorPedido")]
        public decimal ValorPedido { get;  set; }
        [XmlElement("ValorDesconto")]
        public decimal ValorDesconto { get;  set; }
        [XmlElement("ValorTotal")]
        public decimal ValorTotal { get;  set; }

        public EntidadePedido()
        {

        }
        public EntidadePedido(List<EntidadePedidoItem> PedidoItem,
                              DateTime DataPedido,
                              decimal ValorPedido,
                              decimal ValorDesconto,
                             decimal ValorTotal)
        { 

                    this.DataPedido     = DataPedido   ;
                    this.ValorPedido    = ValorPedido  ;
                    this.ValorDesconto  = ValorDesconto;
                    this.ValorTotal = ValorTotal;
                    this.PedidoItem = PedidoItem;


        }
    }
}

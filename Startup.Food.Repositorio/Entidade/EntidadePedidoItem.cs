using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Startup.Food.Repositorio.Entidade
{
    [XmlRoot("PedidoItem")]
    public class EntidadePedidoItem
    {
        [XmlElement("id")]
        public int id { get; set; }
        [XmlElement("IdPedido")]
        public int IdPedido { get; set; }
        [XmlElement("Lanche")]
        public string Lanche { get; set; }
        [XmlElement("Ingredientes")]
        public string Ingredientes { get; set; }
        [XmlElement("ValorTotal")]
        public decimal ValorTotal { get; set; }
        [XmlElement("ValorPedido")]
        public decimal ValorPedido { get; set; }
        [XmlElement("ValorDesconto")]
        public decimal ValorDesconto { get; set; }
        [XmlElement("Promocao")]
        public string Promocao { get; set; }

        public EntidadePedidoItem()
        {

        }

        public EntidadePedidoItem(  int id ,
                                    int IdPedido ,
                                    string Lanche ,
                                    string Ingredientes,
                                    decimal ValorTotal,
                                    decimal ValorPedido,
                                    decimal ValorDesconto,
                                    string Promocao )
        {
         
             this.IdPedido     = IdPedido    ;
             this.Lanche       = Lanche      ;
             this.Ingredientes = Ingredientes;
             this.ValorTotal        = ValorTotal;
            this.ValorPedido = ValorPedido;
            this.ValorDesconto = ValorDesconto;
            this.Promocao = Promocao;
    }

    }
}

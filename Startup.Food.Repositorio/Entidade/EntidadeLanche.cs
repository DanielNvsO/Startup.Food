using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup.Food.Repositorio.Entidade
{
    public class EntidadeLanche
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public List<EntidadeIngrediente> Ingredientes { get; set; }

        public decimal Valor { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Startup.Food.Repositorio.Entidade;
using Startup.Food.Forms.ConexaoAPI;
using System.Net.Http;
using Newtonsoft.Json;

using Startup.Food.Repositorio.Interface;
using Startup.Food.Repositorio.Service.Promocao;
using Startup.Food.Repositorio.Service;

namespace Startup.Food.Forms
{
    public partial class CriarPedido : Form
    {
        public CriarPedido()
        {
            InitializeComponent();
        }


        public List<EntidadeLanche> EntidadeLanches;
        public List<EntidadeIngrediente> EntidadeIngredientes;

        private void CriarPedido_Load(object sender, EventArgs e)
        {
            
        }

        public void LanchesIngredientes()
        {
            try { 

                EntidadeLanche dr = (EntidadeLanche)LanchesGrid.Rows[LanchesGrid.SelectedCells[0].RowIndex].DataBoundItem;



                foreach (var ingre in EntidadeIngredientes)
                {
                    ingre.Quantidade = 0;

                    foreach (var ingreLanche in dr.Ingredientes) {
                        if (ingre.Codigo == ingreLanche.Codigo)
                            ingre.Quantidade = ingreLanche.Quantidade;
                    }
                    
                }

                IngredientesGrid.Refresh();


            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        private DataTable Lanches = new DataTable();

        private void AdicionarLanche_Click(object sender, EventArgs e)
        {
            

            try
            {
                if (LanchesGrid.RowCount == 0)
                    return;

                decimal Valor = 0;
                EntidadeLanche dr = (EntidadeLanche)LanchesGrid.Rows[LanchesGrid.SelectedCells[0].RowIndex].DataBoundItem;
                List<EntidadeIngrediente> ingrediente = (List<EntidadeIngrediente>)IngredientesGrid.DataSource;

                EntidadeLanche Lanche = new EntidadeLanche();
                StringBuilder ingredientesBuilder = new StringBuilder();

                Lanche.Codigo = dr.Codigo;
                Lanche.Descricao = dr.Descricao;
                Lanche.Ingredientes = ingrediente;

                foreach(var ingre in ingrediente)
                {
                    if (ingre.Quantidade > 0)
                        ingredientesBuilder.Append(ingre.Descricao + ": " + ingre.Quantidade + " ");
                 
                    Valor = Valor + (ingre.Valor * ingre.Quantidade);
                }

                Lanche.Valor = Valor;

                IPromocao light = new Light();
                IPromocao muitaCarne = new MuitaCarne();
                IPromocao muitoQueijo = new MuitoQueijo();

                ServicePromocao promocao = new ServicePromocao();

                promocao.CalcularPromocao(Lanche, light);
                promocao.CalcularPromocao(Lanche, muitaCarne);
                promocao.CalcularPromocao(Lanche, muitoQueijo);



                LanchesAdicionadoGrid.Rows.Add(Lanche.Descricao,
                                            Decimal.Round(Lanche.Valor,2), 
                                            ingredientesBuilder.ToString(), 
                                            promocao.NomePromocao,
                                            Decimal.Round(Valor,2),
                                            Decimal.Round(Valor - Lanche.Valor,2));

                ValorPedido.Text = ValorPedido.Text.Replace("R$ ","");
                ValorDesconto.Text = ValorDesconto.Text.Replace("R$ ", "");
                ValorTotal.Text = ValorTotal.Text.Replace("R$ ", "");

                ValorPedido.Text = "R$ " + (Decimal.Round(Valor, 2) + Decimal.Round(Decimal.Parse(ValorPedido.Text),2)).ToString();
                ValorDesconto.Text = "R$ " + (Decimal.Round(Valor - Lanche.Valor, 2) + Decimal.Round(Decimal.Parse(ValorDesconto.Text), 2)).ToString();
                ValorTotal.Text = "R$ " + (Decimal.Round(Lanche.Valor, 2) + Decimal.Round(Decimal.Parse(ValorTotal.Text), 2)).ToString();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LanchesGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                LanchesIngredientes();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LanchesAdicionadoGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                ValorPedido.Text = ValorPedido.Text.Replace("R$ ", "");
                ValorDesconto.Text = ValorDesconto.Text.Replace("R$ ", "");
                ValorTotal.Text = ValorTotal.Text.Replace("R$ ", "");

                ValorPedido.Text = "R$ " + (Decimal.Parse(ValorPedido.Text) - Decimal.Parse(e.Row.Cells[4].Value.ToString())).ToString();
                ValorDesconto.Text = "R$ " + (Decimal.Parse(ValorDesconto.Text) - Decimal.Parse(e.Row.Cells[5].Value.ToString())).ToString();
                ValorTotal.Text = "R$ " + (Decimal.Parse(ValorTotal.Text) - Decimal.Parse(e.Row.Cells[1].Value.ToString())).ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FinalizarPedido_Click(object sender, EventArgs e)
        {
            try
            {

                if (LanchesAdicionadoGrid.RowCount <= 1)
                    return;

                LanchesIngredientes();

                LanchesAdicionadoGrid.Rows.Clear();

                EntidadeLanches = new List<EntidadeLanche>();
                EntidadeIngredientes = new List<EntidadeIngrediente>();

                LanchesGrid.DataSource = EntidadeLanches;
                IngredientesGrid.DataSource = EntidadeIngredientes;

                ValorPedido.Text = "0";
                ValorDesconto.Text = "0";
                ValorTotal.Text = "0";

                timer1.Stop();

                Hora = 0;
                Minuto = 0;
                Segundo = 0;

                Tempo.Text = "00:00:00";

                MessageBox.Show("Pedido Finalizado!", "Mensagem");

            }
            catch(Exception ex)
            {
                throw ex;

            }
        }

        private void IniciarPedido_Click(object sender, EventArgs e)
        {
            ExecutarAPI ExecAPI;
            HttpResponseMessage msg;

            try
            {

                Tempo.Text = "CARREGANDO..";

                 ExecAPI = new ExecutarAPI();

                msg = ExecAPI.POST(null, "Lanche/ConsultarLanches");

                EntidadeLanches = JsonConvert.DeserializeObject<List<EntidadeLanche>>(msg.Content.ReadAsStringAsync().Result);

                LanchesGrid.DataSource = EntidadeLanches;
                LanchesGrid.Refresh();
                LanchesGrid.Columns[0].Visible = false;
                LanchesGrid.Columns[1].HeaderText = "Código";
                LanchesGrid.Columns[2].HeaderText = "Detalhe Lanche";
                LanchesGrid.Columns[2].Visible = false;

                msg = ExecAPI.POST(null, "Lanche/ConsultarIngredientes");

                EntidadeIngredientes = JsonConvert.DeserializeObject<List<EntidadeIngrediente>>(msg.Content.ReadAsStringAsync().Result);

                IngredientesGrid.DataSource = EntidadeIngredientes;

                IngredientesGrid.Columns[0].Visible = false;
                IngredientesGrid.Columns[1].Visible = false;
                IngredientesGrid.Columns[2].HeaderText = "Ingrediente";
                IngredientesGrid.Columns[2].ReadOnly = true;
                IngredientesGrid.Columns[3].ReadOnly = true;


                LanchesIngredientes();

                timer1.Start();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Hora    { get; set; }
        public int Minuto  { get; set; }
        public int Segundo { get; set; }

        private void timer1_Tick(object sender, EventArgs e)
        {

            try { 

                switch (Segundo)
                {
                    case 60:
                        Minuto = Minuto + 1;
                        Segundo = 0;
                        break;
                    default:
                        break;
                }

                switch (Minuto)
                {
                    case 60:
                        Hora = Hora + 1;
                        Minuto = 0;
                        break;
                    default:
                        break;
                }

                Segundo = Segundo + 1;

                Tempo.Text = Hora.ToString("00") + ":" + Minuto.ToString("00") + ":" + Segundo.ToString("00");

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}

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
using Startup.Food.Repositorio.Negocio;
using Startup.Food.Repositorio.Builder;
using Newtonsoft.Json.Linq;

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
        public List<EntidadePedidoItem> EntidadePedidoItem;

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
            catch(Exception)
            {
                throw;
            }
        }


        private DataTable Lanches = new DataTable();

        private void AdicionarLanche_Click(object sender, EventArgs e)
        {
            ExecutarAPI ExecAPI;
            HttpResponseMessage msg;

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

                ExecAPI = new ExecutarAPI();

                msg = ExecAPI.POST(Lanche, "Lanche/CalcularPromocao");

                JObject promocao = JsonConvert.DeserializeObject<JObject>(msg.Content.ReadAsStringAsync().Result);

                var valorCaculado = Decimal.Round(Decimal.Parse(promocao["Valor"].ToString()),2);
                Valor = Decimal.Round(Valor, 2);

                EntidadePedidoItem.Add(new EntidadePedidoItem(0, 0, Lanche.Descricao, ingredientesBuilder.ToString(), valorCaculado, Valor, Valor - valorCaculado, promocao["NomePromocao"].ToString()));

                LanchesAdicionadoGrid.DataSource = EntidadePedidoItem.ToArray();
                LanchesAdicionadoGrid.Refresh();

                ValorPedido.Text = ValorPedido.Text.Replace("R$ ","");
                ValorDesconto.Text = ValorDesconto.Text.Replace("R$ ", "");
                ValorTotal.Text = ValorTotal.Text.Replace("R$ ", "");

                ValorPedido.Text = "R$ " + (Valor + Decimal.Parse(ValorPedido.Text)).ToString();
                ValorDesconto.Text = "R$ " + (Valor - valorCaculado + Decimal.Parse(ValorDesconto.Text)).ToString();
                ValorTotal.Text = "R$ " + (valorCaculado + Decimal.Parse(ValorTotal.Text)).ToString();


            }
            catch (Exception ex)
            {
                Tempo.Text = "00:00:00";
                timer1.Stop();
                Segundo = 0;
                Minuto = 0;
                Hora = 0;
                MessageBox.Show(ex.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                ExecAPI = null;
                msg = null;
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
                MessageBox.Show(ex.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show(ex.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FinalizarPedido_Click(object sender, EventArgs e)
        {
            BuilderPedido Pedido;
            ExecutarAPI ExecAPI;
            HttpResponseMessage msg;

            try
            {

                if (LanchesAdicionadoGrid.RowCount <= 0)
                    return;

                ValorPedido.Text = ValorPedido.Text.Replace("R$ ", "");
                ValorDesconto.Text = ValorDesconto.Text.Replace("R$ ", "");
                ValorTotal.Text = ValorTotal.Text.Replace("R$ ", "");

                Pedido = new BuilderPedido();

                Pedido.DataPedido(DateTime.Now).
                        ValorTotal(Decimal.Parse(ValorTotal.Text)).
                        ValorPedido(Decimal.Parse(ValorPedido.Text)).
                        ValorDesconto(Decimal.Parse(ValorDesconto.Text)).
                        PedidoItem(EntidadePedidoItem);


                ExecAPI = new ExecutarAPI();
                msg = ExecAPI.POST(Pedido.CriarPedido(), "Pedido/InsertPedido");

                bool PedidoCriado = JsonConvert.DeserializeObject<bool>(msg.Content.ReadAsStringAsync().Result);

                if (PedidoCriado) { 

                    EntidadeLanches = new List<EntidadeLanche>();
                    EntidadeIngredientes = new List<EntidadeIngrediente>();
                    EntidadePedidoItem = new List<EntidadePedidoItem>();

                    LanchesGrid.DataSource = EntidadeLanches;
                    IngredientesGrid.DataSource = EntidadeIngredientes;
                    LanchesAdicionadoGrid.DataSource = EntidadePedidoItem;

                    ValorPedido.Text = "0";
                    ValorDesconto.Text = "0";
                    ValorTotal.Text = "0";

                    timer1.Stop();

                    Hora = 0;
                    Minuto = 0;
                    Segundo = 0;

                    Tempo.Text = "00:00:00";

                    MessageBox.Show("Pedido Finalizado!", "Mensagem");

                }else
                {
                    MessageBox.Show("ERRO: Pedido não foi criado!", "Mensagem");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                //LanchesGrid.Columns[2].Visible = false;

                msg = ExecAPI.POST(null, "Lanche/ConsultarIngredientes");

                EntidadeIngredientes = JsonConvert.DeserializeObject<List<EntidadeIngrediente>>(msg.Content.ReadAsStringAsync().Result);

                IngredientesGrid.DataSource = EntidadeIngredientes;

                IngredientesGrid.Columns[0].Visible = false;
                IngredientesGrid.Columns[1].Visible = false;
                IngredientesGrid.Columns[2].HeaderText = "Ingrediente";
                IngredientesGrid.Columns[2].ReadOnly = true;
                IngredientesGrid.Columns[3].ReadOnly = true;

                EntidadePedidoItem = new List<EntidadePedidoItem>();

                LanchesAdicionadoGrid.DataSource = EntidadePedidoItem;

                LanchesAdicionadoGrid.Refresh();
                LanchesAdicionadoGrid.Columns[0].Visible = false;
                LanchesAdicionadoGrid.Columns[1].Visible = false;
                LanchesAdicionadoGrid.Columns[5].Visible = false;
                LanchesAdicionadoGrid.Columns[6].Visible = false;

                LanchesIngredientes();

                timer1.Start();


            }
            catch (Exception ex)
            {
                Tempo.Text = "00:00:00";
                MessageBox.Show(ex.Message.ToString(),"Erro",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                
                ExecAPI = null;
                msg = null ;
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
                MessageBox.Show(ex.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void LanchesAdicionadoGrid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode != Keys.Delete)
                    return;

                EntidadePedidoItem pedidoItem = (EntidadePedidoItem)LanchesAdicionadoGrid.Rows[LanchesAdicionadoGrid.SelectedCells[0].RowIndex].DataBoundItem;

                ValorPedido.Text = ValorPedido.Text.Replace("R$ ", "");
                ValorDesconto.Text = ValorDesconto.Text.Replace("R$ ", "");
                ValorTotal.Text = ValorTotal.Text.Replace("R$ ", "");

                ValorPedido.Text = "R$ " + (Decimal.Parse(ValorPedido.Text) - pedidoItem.ValorPedido).ToString();
                ValorDesconto.Text = "R$ " + (Decimal.Parse(ValorDesconto.Text) - pedidoItem.ValorDesconto).ToString();
                ValorTotal.Text = "R$ " + (Decimal.Parse(ValorTotal.Text) - pedidoItem.ValorTotal).ToString();

                EntidadePedidoItem.RemoveAt(LanchesAdicionadoGrid.SelectedCells[0].RowIndex);
                LanchesAdicionadoGrid.DataSource = EntidadePedidoItem.ToArray();
                LanchesAdicionadoGrid.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}

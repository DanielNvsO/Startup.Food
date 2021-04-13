using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Startup.Food.Repositorio.Entidade;
using Startup.Food.Repositorio.Builder.Conexao;
using System.Data.SqlClient;

namespace Startup.Food.Repositorio.Repositorio
{
    public class RepositorioLanche
    {
        //Consultar
        public List<EntidadeLanche> ConsultarLanches()
        {

            Conexao strcn = new Conexao();
            SqlConnection cn = strcn.GetConnection();
            List<EntidadeLanche> _return = new List<EntidadeLanche>();
            SqlCommand cmd;
            EntidadeLanche lanche;

            try
            {
                cmd = new SqlCommand("prd_ConLanches", cn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (cmd)
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {

                            while (dr.Read())
                            {
                                lanche = new EntidadeLanche();
                                lanche.Id = int.Parse(dr["Id"].ToString());
                                lanche.Codigo = dr["Codigo"].ToString();
                                lanche.Descricao = dr["Descricao"].ToString();
                                lanche.Valor = decimal.Parse(dr["Valor"].ToString());

                                lanche.Ingredientes = ConsultarIngredientesLanche(lanche);

                                _return.Add(lanche);

                            }
                        }
                    }

                    return _return;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                strcn = null;
                cn = null;
                _return = null;
                cmd = null;
                lanche = null;
            }

        }

        //Consultar
        internal List<EntidadeIngrediente> ConsultarIngredientesLanche(EntidadeLanche lanche)
        {

            Conexao strcn = new Conexao();
            SqlConnection cn = strcn.GetConnection();
            List<EntidadeIngrediente> _return = new List<EntidadeIngrediente>();
            SqlCommand cmd;
            EntidadeIngrediente ingredientes;

            try
            {
                cmd = new SqlCommand("prd_ConIngredientesLanche", cn);

                cmd.Parameters.AddWithValue("@IdLanche", lanche.Id);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (cmd)
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {

                            while (dr.Read())
                            {
                                ingredientes = new EntidadeIngrediente();
                                ingredientes.Id = int.Parse(dr["Id"].ToString());
                                ingredientes.Codigo = dr["Codigo"].ToString();
                                ingredientes.Descricao = dr["Descricao"].ToString();
                                ingredientes.Valor = decimal.Parse(dr["Valor"].ToString());
                                ingredientes.Quantidade = int.Parse(dr["Quantidade"].ToString());

                                _return.Add(ingredientes);

                            }
                        }
                    }

                    return _return;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                strcn = null;
                cn = null;
                _return = null;
                cmd = null;
                ingredientes = null;
            }

        }

        //Consultar
        public List<EntidadeIngrediente> ConsultarIngredientes()
        {

            Conexao strcn = new Conexao();
            SqlConnection cn = strcn.GetConnection();
            List<EntidadeIngrediente> _return = new List<EntidadeIngrediente>();
            SqlCommand cmd;
            EntidadeIngrediente ingredientes;

            try
            {
                cmd = new SqlCommand("prd_ConIngredientes", cn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (cmd)
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {

                            while (dr.Read())
                            {
                                ingredientes = new EntidadeIngrediente();
                                ingredientes.Id = int.Parse(dr["Id"].ToString());
                                ingredientes.Codigo = dr["Codigo"].ToString();
                                ingredientes.Descricao = dr["Descricao"].ToString();
                                ingredientes.Valor = decimal.Parse(dr["Valor"].ToString());
                               
                                _return.Add(ingredientes);

                            }
                        }
                    }

                    return _return;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                strcn = null;
                cn = null;
                _return = null;
                cmd = null;
                ingredientes = null;
            }

        }
    }
}

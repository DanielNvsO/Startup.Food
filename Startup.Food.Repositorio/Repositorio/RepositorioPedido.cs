using Startup.Food.Repositorio.Builder.Conexao;
using Startup.Food.Repositorio.Entidade;
using Startup.Food.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Startup.Food.Repositorio.Util;


namespace Startup.Food.Repositorio.Repositorio
{
    public class RepositorioPedido : IRepositorioPedido
    {
        //Consultar
        public bool InsertPedido(EntidadePedido Pedido)
        {

            Conexao strcn = new Conexao();
            SqlConnection cn = strcn.GetConnection();
            SqlCommand cmd;
           
            try
            {

                string resultSerial = UtilSerial.Serialize<EntidadePedido>(Pedido);

                cmd = new SqlCommand("prd_InsertPedido", cn);

                cmd.Parameters.AddWithValue("@doc", resultSerial);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (cmd)
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {

                            dr.Read();
                            if (dr["Resultado"].ToString() == "OK")
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }


                        }
                    }

                    return false;
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
                cmd = null;

            }

        }
    }
}

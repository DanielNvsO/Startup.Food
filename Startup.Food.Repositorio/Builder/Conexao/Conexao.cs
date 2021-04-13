using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Startup.Food.Repositorio.Builder.Conexao
{
    
    public class Conexao
    {
        public string _connectionString = @"Data Source=den1.mssql7.gear.host;Initial Catalog=dbstartupfood;User ID=dbstartupfood;Password=Sg51_k5Lo!oS";

        SqlConnection sqlCon = null;

        public SqlConnection GetConnection()
        {
            try { 
                sqlCon = new SqlConnection(_connectionString);

                sqlCon.Open();

                return sqlCon;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}

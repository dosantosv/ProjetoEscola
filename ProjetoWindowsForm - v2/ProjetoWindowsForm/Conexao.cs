using System;
using System.Configuration;
using MySql.Data.MySqlClient;


namespace ProjetoWindowsForm
{
    public class Conexao
    {
        string conexao = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public MySqlConnection con = null;

        public void AbrirConexao()
        {
            try
            {
                con = new MySqlConnection(conexao);
                con.Open();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void FecharConexao()
        {
            try
            {
                con = new MySqlConnection(conexao);
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

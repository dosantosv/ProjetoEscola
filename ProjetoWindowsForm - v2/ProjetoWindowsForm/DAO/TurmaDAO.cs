using MySql.Data.MySqlClient;
using ProjetoWindowsForm.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjetoWindowsForm.DAO
{
    public class TurmaDAO
    {
        Conexao con = new Conexao();

        #region CBSALA
        public List<Turma> Listar()
        {
            try
            {
                con.FecharConexao();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM turmas", con.con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                var turmas = new List<Turma>();

                foreach(DataRow dr in dt.Rows)
                {
                    var sala = Convert.ToString(dr["turma"]);
                    turmas.Add(new Turma(sala));
                }
                return turmas;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.FecharConexao();
            }
        }
        #endregion
    }
}

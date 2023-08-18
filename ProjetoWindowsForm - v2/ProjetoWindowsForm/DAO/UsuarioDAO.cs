using MySql.Data.MySqlClient;
using ProjetoWindowsForm.Entidades;
using ProjetoWindowsForm.Repository;
using System;

namespace ProjetoWindowsForm.DAO
{
    public class UsuarioDAO
    {
        MySqlCommand sql;
        Conexao con = new Conexao();

        public Diretoria Login(Diretoria dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("SELECT * FROM diretoria where usuario = @usuario AND senha = @senha", con.con);
                sql.Parameters.AddWithValue("@usuario", dado.Usuario);
                sql.Parameters.AddWithValue("@senha", dado.Senha);
                MySqlDataReader dr;
                dr = sql.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dado.Usuario = Convert.ToString(dr["usuario"]);
                        dado.Senha = Convert.ToString(dr["senha"]);
                    }
                    Logado.Usuario = dado.Usuario;
                }
                else
                {
                    dado.Usuario = null;
                    dado.Senha = null;
                }
                return dado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Professor LoginProf(Professor dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("SELECT * FROM professores where usuario = @usuario AND senha = @senha", con.con);
                sql.Parameters.AddWithValue("@usuario", dado.Usuario);
                sql.Parameters.AddWithValue("@senha", dado.Senha);
                MySqlDataReader dr;
                dr = sql.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dado.Usuario = Convert.ToString(dr["usuario"]);
                        dado.Senha = Convert.ToString(dr["senha"]);
                    }
                    Logado.Sala = Convert.ToString(dr["sala"]);
                    Logado.Materia = Convert.ToString(dr["materia"]);
                    Logado.Usuario = dado.Usuario;
                }
                else
                {
                    dado.Usuario = null;
                    dado.Senha = null;
                }
                return dado;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}


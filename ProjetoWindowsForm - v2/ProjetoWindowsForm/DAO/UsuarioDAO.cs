using MySql.Data.MySqlClient;
using ProjetoWindowsForm.Entidades;
using ProjetoWindowsForm.Entities;
using ProjetoWindowsForm.Repository;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjetoWindowsForm.DAO
{
    public class UsuarioDAO
    {
        MySqlCommand sql;
        Conexao con = new Conexao();

        public Usuario LoginDiretoria(Diretoria diretoria)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("SELECT * FROM diretoria where usuario = @usuario AND senha = @senha", con.con);
                sql.Parameters.AddWithValue("@usuario", diretoria.Usuario);
                sql.Parameters.AddWithValue("@senha", diretoria.Senha);
                MySqlDataReader dr;
                dr = sql.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        diretoria.Usuario = Convert.ToString(dr["usuario"]);
                        diretoria.Senha = Convert.ToString(dr["senha"]);
                    }
                    Login.Usuario = diretoria.Usuario;
                    Login.Permissao = diretoria.Permissao;
                }
                else
                {
                    diretoria.Usuario = null;
                    diretoria.Senha = null;
                }
                return diretoria;
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

        public Usuario LoginProf(Professor professor)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("SELECT * FROM professores where usuario = @usuario AND senha = @senha", con.con);
                sql.Parameters.AddWithValue("@usuario", professor.Usuario);
                sql.Parameters.AddWithValue("@senha", professor.Senha);
                MySqlDataReader dr;
                dr = sql.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        professor.Usuario = Convert.ToString(dr["usuario"]);
                        professor.Senha = Convert.ToString(dr["senha"]);
                    }
                    Login.Sala = Convert.ToString(dr["sala"]);
                    Login.Materia = Convert.ToString(dr["materia"]);
                    Login.Usuario = professor.Usuario;
                    Login.Permissao = professor.Permissao;
                }
                else
                {
                    professor.Usuario = null;
                    professor.Senha = null;
                }
                return professor;
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
    }
}


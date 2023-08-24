using MySql.Data.MySqlClient;
using ProjetoWindowsForm.Entidades;
using ProjetoWindowsForm.Repository;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjetoWindowsForm.DAO
{
    public class ProfessorDAO
    {
        MySqlCommand sql;
        Conexao con = new Conexao();
        Random random = new Random(); 

        #region CRUD
        public void CadastrarProfessor(Professor professor)
        {
            try
            {
                con.AbrirConexao();
                professor.Id = random.Next(1, 100);
                sql = new MySqlCommand("INSERT INTO professores(id, nome, nascimento, sala, sexo, materia, usuario, senha) VALUES(@id, @nome, @nascimento, @sala, @sexo, @materia, @usuario, @senha)", con.con);
                sql.Parameters.AddWithValue("@id", professor.Id);
                sql.Parameters.AddWithValue("@nome", professor.Nome);
                sql.Parameters.AddWithValue("@nascimento", professor.Nascimento);
                sql.Parameters.AddWithValue("@sala", professor.Sala);
                sql.Parameters.AddWithValue("@sexo", professor.Sexo);
                sql.Parameters.AddWithValue("@materia", professor.Materia);
                sql.Parameters.AddWithValue("@usuario", professor.Usuario);
                sql.Parameters.AddWithValue("@senha", professor.Senha);
                sql.ExecuteNonQuery();
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

        public void EditarProfessor(Professor professor)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("UPDATE professores SET nome = @nome, nascimento = @nascimento, sala = @sala, sexo = @sexo, materia = @materia, usuario = @usuario, senha = @senha WHERE id = @id", con.con);
                sql.Parameters.AddWithValue("@nome", professor.Nome);
                sql.Parameters.AddWithValue("@nascimento", professor.Nascimento);
                sql.Parameters.AddWithValue("@sala", professor.Sala);
                sql.Parameters.AddWithValue("@sexo", professor.Sexo);
                sql.Parameters.AddWithValue("@materia", professor.Materia);
                sql.Parameters.AddWithValue("@usuario", professor.Usuario);
                sql.Parameters.AddWithValue("@senha", professor.Senha);
                sql.Parameters.AddWithValue("@id", professor.Id);
                sql.ExecuteNonQuery();
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

        public void ExcluirProfessor(Professor professor)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("DELETE FROM professores WHERE id = @id", con.con);
                sql.Parameters.AddWithValue("@id", professor.Id);
                sql.ExecuteNonQuery();
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

        #region GRID PROFESSOR
        public List<Professor> ObterListTodosProfessores()
        {
            try
            {
                con.AbrirConexao();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM professores order by id desc", con.con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                List<Professor> professores = new List<Professor>();

                foreach (DataRow dr in dt.Rows)
                {
                    var id = Convert.ToInt32(dr["id"]);
                    var nome = Convert.ToString(dr["nome"]);
                    var dataNascimento = Convert.ToDateTime(dr["nascimento"]);
                    var sala = Convert.ToString(dr["sala"]);
                    var sexo = Convert.ToString(dr["sexo"]);
                    var materia = Convert.ToString(dr["materia"]);
                    var usuario = Convert.ToString(dr["usuario"]);
                    var senha = Convert.ToString(dr["senha"]);
                    professores.Add(new Professor(id, nome, dataNascimento, sala, sexo, materia, usuario, senha));
                }
                return professores;
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

        #region GRID MEDIAS

        public List<Professor> ObterListaAlunosPorMateriaDeAcordoComProfessorLogado()
        {
            try
            {
                con.AbrirConexao();
                MySqlCommand sql = new MySqlCommand("SELECT id, nome, sala, materia FROM professores WHERE materia = @materia", con.con);
                sql.Parameters.AddWithValue("@materia", Logado.Materia);

                MySqlDataAdapter da = new MySqlDataAdapter(sql);
                DataTable dt = new DataTable();
                da.Fill(dt);

                var alunos = new List<Professor>();

                foreach (DataRow dr in dt.Rows)
                {
                    var id = Convert.ToInt16(dr["id"]);
                    var nome = Convert.ToString(dr["nome"]);
                    var sala = Convert.ToString(dr["sala"]);
                    var materia = Convert.ToString(dr["materia"]);
                    alunos.Add(new Professor(id, nome, sala, materia));
                }
                return alunos;
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

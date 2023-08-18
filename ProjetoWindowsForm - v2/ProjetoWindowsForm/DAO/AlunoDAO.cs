using System;
using System.Collections.Generic;
using System.Data;
using ProjetoWindowsForm.Entidades;
using MySql.Data.MySqlClient;
using ProjetoWindowsForm.ViewModel;
using ProjetoWindowsForm.Repository;

namespace ProjetoWindowsForm.DAO
{
    public class AlunoDAO
    {
        MySqlCommand sql, sqlN;
        Conexao con = new Conexao();

        public List<Professor> GetListTurmaProfessores()
        {
            try
            {
                con.AbrirConexao();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT sala FROM professores", con.con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                var turmaProfessores = new List<Professor>();

                foreach (DataRow dr in dt.Rows)
                {
                    var sala = Convert.ToString(dr["sala"]);
                    turmaProfessores.Add(new Professor(sala));
                }
                return turmaProfessores;
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
        public List<Aluno> GetListAlunosAll()
        {
            try
            {
                con.AbrirConexao();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT ra, nome, nascimento, sexo, sala FROM alunos order by ra desc", con.con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                var alunos = new List<Aluno>();

                foreach (DataRow dr in dt.Rows)
                {
                    var ra = Convert.ToInt32(dr["ra"]);
                    var nome = Convert.ToString(dr["nome"]);
                    var dataNascimento = Convert.ToDateTime(dr["nascimento"]);
                    var sexo = Convert.ToString(dr["sexo"]);
                    var sala = Convert.ToString(dr["sala"]);
                    alunos.Add(new Aluno(ra, nome, dataNascimento, sexo, sala));
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

        public void CadastrarAluno(Aluno dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("INSERT INTO alunos(nome, nascimento, sala, sexo) VALUES(@nome, @nascimento, @sala, @sexo)", con.con);
                sql.Parameters.AddWithValue("@nome", dado.Nome);
                sql.Parameters.AddWithValue("@nascimento", dado.Nascimento);
                sql.Parameters.AddWithValue("@sala", dado.Sala);
                sql.Parameters.AddWithValue("@sexo", dado.Sexo);
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

        public void ExcluirAluno(Aluno dado)
        {
            try
            {
                con.AbrirConexao();
                sqlN = new MySqlCommand("DELETE FROM alunos_materias WHERE ra_aluno = @ra", con.con);
                sqlN.Parameters.AddWithValue("@ra", dado.Ra);
                sqlN.ExecuteNonQuery(); 
                sql = new MySqlCommand("DELETE FROM alunos WHERE ra = @ra", con.con);
                sql.Parameters.AddWithValue("@ra", dado.Ra);
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

        public void EditarAluno(Aluno dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("UPDATE alunos SET nome = @nome, nascimento = @nascimento, sala = @sala, sexo = @sexo WHERE ra = @ra", con.con);
                sql.Parameters.AddWithValue("@nome", dado.Nome);
                sql.Parameters.AddWithValue("@nascimento", dado.Nascimento);
                sql.Parameters.AddWithValue("@sala", dado.Sala);
                sql.Parameters.AddWithValue("@sexo", dado.Sexo);
                sql.Parameters.AddWithValue("@ra", dado.Ra);
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

        public List<Aluno> ObterListaAlunos()
        {
            try
            {
                con.AbrirConexao();
                MySqlCommand sql = new MySqlCommand("SELECT ra, nome, sala FROM alunos", con.con);
                return ObterListaAlunos(sql);
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

        #region MEDIAS
        public List<Aluno> GetListAlunoPerSalaForGlobalVar()
        {
            try
            {
                con.AbrirConexao();
                MySqlCommand sql = new MySqlCommand("SELECT ra, nome, sala FROM alunos WHERE sala = @sala", con.con);
                sql.Parameters.AddWithValue("@sala", Logado.Sala);

                return ObterListaAlunos(sql);
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

        #region FILTERS BOLETIM

        public List<Aluno> ObterListaAlunosPorRa(AlunoMateriasVM aluno)
        {
            try
            {
                con.AbrirConexao();
                MySqlCommand sql = new MySqlCommand("SELECT ra, nome, sala FROM alunos WHERE ra LIKE @ra", con.con);
                sql.Parameters.AddWithValue("@ra", aluno.Ra + "%");

                return ObterListaAlunos(sql);
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

        public List<Aluno> ObterListaAlunoPorNome(AlunoMateriasVM aluno)
        {
            try
            {
                con.AbrirConexao();
                MySqlCommand sql = new MySqlCommand("SELECT ra, nome, sala FROM alunos WHERE nome LIKE @nome", con.con);
                sql.Parameters.AddWithValue("@nome", aluno.Nome + "%");
                return ObterListaAlunos(sql);
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

        public List<Aluno> ObterListaAlunoPorSala(AlunoMateriasVM aluno)
        {
            try
            {
                con.AbrirConexao();
                MySqlCommand sql = new MySqlCommand("SELECT ra, nome, sala FROM alunos WHERE sala = @sala", con.con);
                sql.Parameters.AddWithValue("@sala", aluno.Sala);

                return ObterListaAlunos(sql);
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

        public List<Aluno> ObterListaAlunoPorRaENome(AlunoMateriasVM aluno)
        {
            try
            {
                con.AbrirConexao();
                MySqlCommand sql = new MySqlCommand("SELECT ra, nome, sala FROM alunos WHERE ra LIKE @ra AND nome LIKE @nome", con.con);
                sql.Parameters.AddWithValue("@ra", aluno.Ra + "%");
                sql.Parameters.AddWithValue("@nome", aluno.Nome + "%");

                return ObterListaAlunos(sql);
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

        public List<Aluno> ObterListaAlunoPorNomeESala(AlunoMateriasVM aluno)
        {
            try
            {
                con.AbrirConexao();
                MySqlCommand sql = new MySqlCommand("SELECT ra, nome, sala FROM alunos WHERE nome LIKE @nome AND sala = @sala", con.con);
                sql.Parameters.AddWithValue("@nome", aluno.Nome + "%");
                sql.Parameters.AddWithValue("@sala", aluno.Sala);

                return ObterListaAlunos(sql);
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

        public List<Aluno> ObterListaAlunoPorNomeSalaERa(AlunoMateriasVM aluno)
        {
            try
            {
                con.AbrirConexao();
                MySqlCommand sql = new MySqlCommand("SELECT ra, nome, sala FROM alunos WHERE ra LIKE @ra AND nome LIKE @nome AND sala = @sala", con.con);
                sql.Parameters.AddWithValue("@nome", aluno.Ra + "%");
                sql.Parameters.AddWithValue("@nome", aluno.Nome + "%");
                sql.Parameters.AddWithValue("@sala", aluno.Sala);

                return ObterListaAlunos(sql);
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

        public List<Aluno> ObterListaAlunos(MySqlCommand sql)
        {
            MySqlDataAdapter da = new MySqlDataAdapter(sql);
            DataTable dt = new DataTable();
            da.Fill(dt);

            var alunos = new List<Aluno>();

            foreach (DataRow dr in dt.Rows)
            {
                var ra = Convert.ToInt32(dr["ra"]);
                var nome = Convert.ToString(dr["nome"]);
                var sala = Convert.ToString(dr["sala"]);
                alunos.Add(new Aluno(ra, nome, sala));
            }
            return alunos;
        }
        #endregion
    }
}


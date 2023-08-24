using System;
using System.Collections.Generic;
using System.Data;
using ProjetoWindowsForm.Entidades;
using MySql.Data.MySqlClient;
using ProjetoWindowsForm.ViewModel;
using ProjetoWindowsForm.Repository;


namespace ProjetoWindowsForm.DAO
{
    public class MateriaDAO
    {
        MySqlCommand sql;
        Conexao con = new Conexao();

        #region CRUD
        public void CadastrarNotas(Materia dado, AlunoProfessorVM dados)
        {
			try
			{
                con.AbrirConexao();
                sql = new MySqlCommand("INSERT INTO alunos_materias(materia, n1, n2, n3, n4, media, ra_aluno, status) VALUES(@materia, @n1, @n2, @n3, @n4, @media, @ra, @status) ", con.con);
                sql.Parameters.AddWithValue("@materia", dado.NomeMateria);
                sql.Parameters.AddWithValue("@n1", dado.Notas[0]);
                sql.Parameters.AddWithValue("@n2", dado.Notas[1]);
                sql.Parameters.AddWithValue("@n3", dado.Notas[2]);
                sql.Parameters.AddWithValue("@n4", dado.Notas[3]);
                sql.Parameters.AddWithValue("@media", dado.Media);
                sql.Parameters.AddWithValue("@ra", dados.Ra);
                sql.Parameters.AddWithValue("@status", dado.Status);
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

        public void EditarNotas(Materia dado, AlunoProfessorVM dados)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("UPDATE alunos_materias SET n1 = @n1, n2 = @n2, n3 = @n3, n4 = @n4, status = @status, media = @media WHERE ra_aluno = @ra", con.con);
                sql.Parameters.AddWithValue("@n1", dado.Notas[0]);
                sql.Parameters.AddWithValue("@n2", dado.Notas[1]);
                sql.Parameters.AddWithValue("@n3", dado.Notas[2]);
                sql.Parameters.AddWithValue("@n4", dado.Notas[3]);
                sql.Parameters.AddWithValue("@status", dado.Status);
                sql.Parameters.AddWithValue("@media", dado.Media);
                sql.Parameters.AddWithValue("@ra", dados.Ra);
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

        public void DeletarNotas(AlunoProfessorVM dados)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("DELETE FROM alunos_materias WHERE ra_aluno = @ra AND materia = @materia", con.con);
                sql.Parameters.AddWithValue("@ra", dados.Ra);
                sql.Parameters.AddWithValue("@materia", Logado.Materia);
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

        #region GRID MEDIAS

        public List<Materia> ObterListaMateriasNotas()
        {
            try
            {
                con.AbrirConexao();
                MySqlCommand sql = new MySqlCommand("SELECT materia, N1, N2, N3, N4, media, status, ra_aluno FROM alunos_materias", con.con);

                return ObterListaMaterias(sql);
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

        #region FILTERS GRID BOLETIM

        public List<Materia> ObterListaMateriasNotasComMedia() 
        {
            try
            {
                con.AbrirConexao();
                MySqlCommand sql = new MySqlCommand("SELECT materia, N1, N2, N3, N4, media, status, ra_aluno FROM alunos_materias WHERE media <> ''", con.con);
                return ObterListaMaterias(sql);
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

        public List<Materia> ObterListaMateriasNotasPorStatus(AlunoMateriasVM materia)
        {
            try
            {
                con.AbrirConexao();
                MySqlCommand sql = new MySqlCommand("SELECT materia, N1, N2, N3, N4, media, status, ra_aluno FROM alunos_materias WHERE status = @status", con.con);
                sql.Parameters.AddWithValue("@status", materia.Status);

                return ObterListaMaterias(sql);
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

        public List<Materia> ObterListaMateriasSomenteNome()
        {
            try
            {
                con.AbrirConexao();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT materia FROM materias", con.con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                var listMaterias = new List<Materia>();

                foreach (DataRow dr in dt.Rows)
                {
                    var materia = Convert.ToString(dr["materia"]);
                    listMaterias.Add(new Materia(materia));
                }
                return listMaterias;
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

        public List<Materia> ObterListaMaterias(MySqlCommand sql)
        {
            MySqlDataAdapter da = new MySqlDataAdapter(sql);
            DataTable dt = new DataTable();
            da.Fill(dt);

            var materiasNotas = new List<Materia>();

            foreach (DataRow dr in dt.Rows)
            {
                var materia = Convert.ToString(dr["materia"]);
                var n1 = Convert.ToDecimal(dr["N1"]);
                var n2 = Convert.ToDecimal(dr["N2"]);
                var n3 = Convert.ToDecimal(dr["N3"]);
                var n4 = Convert.ToDecimal(dr["N4"]);
                var media = Convert.ToDecimal(dr["media"]);
                var status = Convert.ToString(dr["status"]);
                var ra = Convert.ToInt32(dr["ra_aluno"]);
                materiasNotas.Add(new Materia(materia, n1, n2, n3, n4, media, status, ra));
            }
            return materiasNotas;
        }
    }
}

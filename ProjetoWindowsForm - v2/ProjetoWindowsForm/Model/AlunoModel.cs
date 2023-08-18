using System;
using System.Collections.Generic;
using NPOI.SS.Formula.Functions;
using ProjetoWindowsForm.DAO;
using ProjetoWindowsForm.Entidades;

namespace ProjetoWindowsForm.Model
{
    public class AlunoModel : IPessoa
    {

        AlunoDAO dao = new AlunoDAO();

        public List<Aluno> GetListAlunosAll()
        {
            try
            {
                return dao.GetListAlunosAll();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<Professor> GetListTurmaProfessores()
        {
            try
            {
                return dao.GetListTurmaProfessores();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Pessoa dado)
        {
            try
            {
                dao.CadastrarAluno((Aluno)dado);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Excluir(Pessoa dado)
        {
            try
            {
                dao.ExcluirAluno((Aluno)dado);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Editar(Pessoa dado)
        {
            try
            {
                dao.EditarAluno((Aluno)dado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

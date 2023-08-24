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

        public List<Aluno> ObterListGeralAlunos()
        {
            try
            {
                return dao.ObterListaTodosAlunos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> Listar<T>() where T : Pessoa
        {
            try
            {
                return dao.ObterListaTurmaProfessores() as List<T>;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Pessoa pessoa)
        {
            try
            {
                dao.CadastrarAluno((Aluno)pessoa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Excluir(Pessoa pessoa)
        {
            try
            {
                dao.ExcluirAluno((Aluno)pessoa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Editar(Pessoa pessoa)
        {
            try
            {
                dao.EditarAluno((Aluno)pessoa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

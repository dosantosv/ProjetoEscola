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

        public List<T> Listar<T>() where T : Pessoa
        {
            try
            {
                return dao.ObterListaTodosAlunos() as List<T>;
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
            catch (Exception)
            {

                throw;
            }
        }

        public void Excluir(Pessoa pessoa)
        {
            try
            {
                dao.ExcluirAluno((Aluno)pessoa);
            }
            catch (Exception )
            {
                throw;
            }
        }

        public void Editar(Pessoa pessoa)
        {
            try
            {
                dao.EditarAluno((Aluno)pessoa);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}

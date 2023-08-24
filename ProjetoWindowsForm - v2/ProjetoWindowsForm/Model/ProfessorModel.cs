using System;
using System.Collections.Generic;
using ProjetoWindowsForm.DAO;
using ProjetoWindowsForm.Entidades;

namespace ProjetoWindowsForm.Model
{

    public class ProfessorModel : IPessoa
    {
        ProfessorDAO dao = new ProfessorDAO();

        public List<T> Listar<T>() where T : Pessoa
        {
            try
            {
                return dao.ObterListTodosProfessores() as List<T>;
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
                dao.CadastrarProfessor((Professor)pessoa);
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
                dao.EditarProfessor((Professor)pessoa);
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
                dao.ExcluirProfessor((Professor)pessoa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

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

        public List<Professor> ObterListaTurmaProfessores()
        {
            try
            {
                return dao.ObterListaTurmaProfessores();
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
            catch (Exception)
            {

                throw;
            }
        }

        public void Editar(Pessoa pessoa)
        {
            try
            {
                dao.EditarProfessor((Professor)pessoa);
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
                dao.ExcluirProfessor((Professor)pessoa);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

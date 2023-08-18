using System;
using System.Collections.Generic;
using ProjetoWindowsForm.DAO;
using ProjetoWindowsForm.Entidades;

namespace ProjetoWindowsForm.Model
{

    public class ProfessorModel : IPessoa
    {
        ProfessorDAO dao = new ProfessorDAO();

        public List<Professor> ObterListTodosProfessores()
        {
            try
            {
                return dao.ObterListTodosProfessores();
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
                dao.CadastrarProfessor((Professor)dado);
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
                dao.EditarProfessor((Professor)dado);
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
                dao.ExcluirProfessor((Professor)dado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

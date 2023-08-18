using ProjetoWindowsForm.DAO;
using ProjetoWindowsForm.Entidades;
using ProjetoWindowsForm.ViewModel;
using System;
using System.Collections.Generic;

namespace ProjetoWindowsForm.Model
{
    public class MateriaModel
    {
        MateriaDAO dao = new MateriaDAO();
        Materia dado = new Materia();
        AlunoProfessorVM dados = new AlunoProfessorVM();
        public void CadastrarNotas(Materia dado, AlunoProfessorVM dados)
        {
            try
            {
                dao.CadastrarNotas(dado, dados);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EditarNotas(Materia dado, AlunoProfessorVM dados)
        {
            try
            {
                dao.EditarNotas(dado, dados);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeletarNotas(AlunoProfessorVM dados)
        {
            try
            {
                dao.DeletarNotas(dados);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Materia> ObterListaMateriasFixa()
        {
            try
            {
                return dao.ObterListaMateriasFixa();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using ProjetoWindowsForm.DAO;
using ProjetoWindowsForm.Entities;

namespace ProjetoWindowsForm.Model
{
    public class TurmaModel
    {
        TurmaDAO dao = new TurmaDAO();
        public List<Turma> Listar()
        {
            try
            {
                return dao.Listar();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

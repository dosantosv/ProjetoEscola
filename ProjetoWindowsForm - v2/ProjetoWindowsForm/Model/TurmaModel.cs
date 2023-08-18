using System;
using System.Data;
using ProjetoWindowsForm.DAO;

namespace ProjetoWindowsForm.Model
{
    public class TurmaModel
    {
        TurmaDAO dao = new TurmaDAO();
        public DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dao.Listar();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

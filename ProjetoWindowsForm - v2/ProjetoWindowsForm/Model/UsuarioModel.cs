using ProjetoWindowsForm.DAO;
using System;
using ProjetoWindowsForm.Entidades;

namespace ProjetoWindowsForm.Model
{
    public class UsuarioModel
    {
        UsuarioDAO dao = new UsuarioDAO();

        public Diretoria Login(Diretoria dado)
        {
            try
            {
                return dao.Login(dado);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Professor LoginProf(Professor dado)
        {
            try
            {
                return dao.LoginProf(dado);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}

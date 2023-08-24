using ProjetoWindowsForm.DAO;
using System;
using ProjetoWindowsForm.Entidades;
using System.Collections.Generic;
using ProjetoWindowsForm.Interface;

namespace ProjetoWindowsForm.Model
{
    public class UsuarioModel
    {
        UsuarioDAO dao = new UsuarioDAO();


        public Diretoria Login(Diretoria admin)
        {
            try
            {
                return dao.Login(admin);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Professor LoginProf(Professor professor)
        {
            try
            {
                return dao.LoginProf(professor);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

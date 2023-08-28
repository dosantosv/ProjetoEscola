using ProjetoWindowsForm.DAO;
using System;
using ProjetoWindowsForm.Entidades;
using System.Collections.Generic;
using ProjetoWindowsForm.Interface;
using ProjetoWindowsForm.Entities;

namespace ProjetoWindowsForm.Model
{
    public class UsuarioModel
    {
        UsuarioDAO dao = new UsuarioDAO();


        public Usuario LoginDiretoria(Diretoria admin)
        {
            try
            {
                return dao.LoginDiretoria(admin);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario LoginProf(Professor professor)
        {
            try
            {
                return dao.LoginProf(professor);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

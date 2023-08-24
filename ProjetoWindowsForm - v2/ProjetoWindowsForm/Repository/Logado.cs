using ProjetoWindowsForm.DAO;
using ProjetoWindowsForm.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWindowsForm.Repository
{
    static class Logado
    {
        public static string Usuario { get; set; }
        public static string Senha { get; set; }    
        public static string Sala { get; set; }
        public static string Materia { get; set; }
        public static string Permissao { get; set; }
    }
}

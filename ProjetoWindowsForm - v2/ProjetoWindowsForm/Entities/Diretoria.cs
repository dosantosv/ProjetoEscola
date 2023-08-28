
using ProjetoWindowsForm.Interface;

namespace ProjetoWindowsForm.Entidades
{
    public class Diretoria : Pessoa, IPermissao
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Permissao => "admin";

        public Diretoria()
        {
        }

        public Diretoria(string usuario, string senha)
        {
            Usuario = usuario;
            Senha = senha;
        }
    }
}

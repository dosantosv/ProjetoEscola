using ProjetoWindowsForm.Entidades;
using System.Collections.Generic;

namespace ProjetoWindowsForm.Model
{
    interface IPessoa
    {
        void Cadastrar(Pessoa pessoa);

        void Excluir(Pessoa pessoa);

        void Editar(Pessoa pessoa);

        List<T> Listar<T>() where T : Pessoa;
    }
}

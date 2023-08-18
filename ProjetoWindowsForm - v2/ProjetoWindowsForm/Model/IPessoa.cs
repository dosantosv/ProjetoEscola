using NPOI.SS.Formula.Functions;
using ProjetoWindowsForm.Entidades;
using System.Collections.Generic;

namespace ProjetoWindowsForm.Model
{
    interface IPessoa
    {
        void Cadastrar(Pessoa dado);

        void Excluir(Pessoa dado);

        void Editar(Pessoa dado);

    }
}

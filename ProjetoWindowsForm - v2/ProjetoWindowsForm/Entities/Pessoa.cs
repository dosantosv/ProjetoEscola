using System;

namespace ProjetoWindowsForm.Entidades
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Sexo { get; set; }

    }
}

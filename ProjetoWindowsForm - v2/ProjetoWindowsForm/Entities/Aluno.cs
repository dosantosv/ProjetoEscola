using System;

namespace ProjetoWindowsForm.Entidades
{
    public class Aluno : Pessoa
    {
        public int Ra { get; set; }
        public string Sala { get; set; }

        public Aluno()
        {
        }

        public Aluno(int ra, string nome, string sala)
        {
            Ra = ra;
            Nome = nome;
            Sala = sala;
        }

        public Aluno(int ra, string nome, DateTime nascimento, string sexo, string sala)
        {
            Ra = ra;
            Nome = nome;
            Nascimento = nascimento;
            Sexo = sexo;
            Sala = sala;
        }

    }
}

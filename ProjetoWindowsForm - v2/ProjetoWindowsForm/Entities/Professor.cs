using System;

namespace ProjetoWindowsForm.Entidades
{
    public class Professor : Pessoa
    {
        public int Id { get; set; }
        public string Sala { get; set; }
        public string Materia { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public Professor()
        {

        }
        public Professor(string sala)
        {
            Sala = sala;
        }
        public Professor(int id, string nome, string sala, string materia) 
        {
            Id = id;
            Nome = nome;
            Sala = sala;
            Materia = materia;
        }


        public Professor(int id, string nome, DateTime nascimento, string sala, string sexo, string materia, string usuario, string senha)
        {
            Id = id;
            Nome = nome;
            Nascimento = nascimento;
            Sala = sala;
            Sexo = sexo;
            Materia = materia;
            Usuario = usuario;
            Senha = senha;
        }

        public Professor(string usuario, string senha)
        {
            Usuario = usuario;
            Senha = senha;
        }
    }
}



namespace ProjetoWindowsForm.Entidades
{
    public class Materia
    {
        public string NomeMateria { get; set; }
        public decimal[] Notas { get; set; }
        public decimal Media { get; set; }
        public string Status { get; set; }
        public int Ra { get; set; }
        public Materia()
        {
            Notas = new decimal[4];
        }

        public Materia(string nomeMateria)
        {
            NomeMateria = nomeMateria;
        }

        public Materia(string nomeMateria, decimal n1, decimal n2, decimal n3, decimal n4, decimal media, string status, int ra)
        {
            NomeMateria = nomeMateria;
            Notas = new decimal[4];
            Notas[0] = n1;
            Notas[1] = n2;
            Notas[2] = n3;
            Notas[3] = n4;
            Media = media;
            Status = status;
            Ra = ra;
        }
    }
}

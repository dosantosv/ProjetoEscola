using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWindowsForm.Entities
{
    public class Turma
    {
        public string Sala { get; set; }

        public Turma(string sala)
        {
            Sala = sala;
        }
    }
}

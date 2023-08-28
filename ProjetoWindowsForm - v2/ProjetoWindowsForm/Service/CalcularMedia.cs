using ProjetoWindowsForm.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWindowsForm.Service
{
    public class CalcularMedia
    {
        public void ObterNotasEStatusMateria(Materia dado)
        {
			try
			{
                decimal media = Convert.ToDecimal(dado.Notas[0] + dado.Notas[1] + dado.Notas[2] + dado.Notas[3]) / 4;

                dado.Media = media;
                if (dado.Media >= 7 && dado.Media <= 10)
                {
                    dado.Status = "Aprovado";
                }
                else if (dado.Media >= 0 && dado.Media <= 7)
                {
                    dado.Status = "Reprovado";
                }
                else
                {
                    dado.Status = "Notas não informadas!";
                }
            }
			catch (Exception)
			{
				throw;
			}
        }
    }
}

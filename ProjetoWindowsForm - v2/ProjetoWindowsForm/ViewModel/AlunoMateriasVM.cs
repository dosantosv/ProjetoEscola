using ProjetoWindowsForm.DAO;
using ProjetoWindowsForm.Entidades;
using ProjetoWindowsForm.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ProjetoWindowsForm.ViewModel
{
    public class AlunoMateriasVM
    {
        AlunoDAO daoAluno = new AlunoDAO();
        MateriaDAO daoMateria = new MateriaDAO();

        #region ALUNO
        public long Ra { get; set; }
        public string Nome { get; set; }
        public string Sala { get; set; }
        #endregion

        #region MATERIA
        public string NomeMateria { get; set; }
        public string N1 { get; set; }
        public string N2 { get; set; }
        public string N3 { get; set; }
        public string N4 { get; set; }
        public string Media { get; set; }
        public string Status { get; set; }
        public int Ra_aluno { get; set; }
        #endregion

        public AlunoMateriasVM()
        {

        }

        public AlunoMateriasVM(string nomeMateria)
        {
            NomeMateria = nomeMateria;
        }

        public AlunoMateriasVM(long ra, string nome, string sala, string nomeMateria, string n1, string n2, string n3, string n4, string media, string status)
        {
            Ra = ra;
            Nome = nome;
            Sala = sala;
            NomeMateria = nomeMateria;
            N1 = n1;
            N2 = n2;
            N3 = n3;
            N4 = n4;
            Media = media;
            Status = status;
        }

        public List<AlunoMateriasVM> ObterListaAlunosEMaterias(List<AlunoMateriasVM> alunos, List<AlunoMateriasVM> materias, List<AlunoMateriasVM> dadosCompletosList)
        {
            foreach (var aluno in alunos)
            {
                var notasDoAluno = materias.Where(m => m.Ra_aluno == aluno.Ra && !string.IsNullOrEmpty(m.Media));

                foreach (var materia in notasDoAluno)
                {
                    var dadosCompletos = new AlunoMateriasVM(
                        aluno.Ra,
                        aluno.Nome,
                        aluno.Sala,
                        materia.NomeMateria,
                        materia.N1,
                        materia.N2,
                        materia.N3,
                        materia.N4,
                        materia.Media,
                        materia.Status
                    );

                    dadosCompletosList.Add(dadosCompletos);
                }
            }

            return dadosCompletosList;
        }



        #region PARA VIEW MODEL

        public List<AlunoMateriasVM> ObterListaMateriasParaViewModel(List<AlunoMateriasVM> materias, List<AlunoMateriasVM> dadosCompletosList)
        {
            foreach (var materia in materias)
            {
                var dadosCompletos = new AlunoMateriasVM(
                    materia.NomeMateria
                );

                dadosCompletosList.Add(dadosCompletos);
            }


            return dadosCompletosList;
        }

        public List<AlunoMateriasVM> ObterListaAlunoParaViewModel(List<Aluno> alunos)
        {
            List<AlunoMateriasVM> alunoMateriasVMList = new List<AlunoMateriasVM>();

            foreach (Aluno aluno in alunos)
            {
                AlunoMateriasVM alunoMateriasVM = new AlunoMateriasVM();
                alunoMateriasVM.Ra = aluno.Ra;
                alunoMateriasVM.Nome = aluno.Nome;
                alunoMateriasVM.Sala = aluno.Sala;

                alunoMateriasVMList.Add(alunoMateriasVM);
            }

            return alunoMateriasVMList;
        }

        public List<AlunoMateriasVM> ObterListaMateriaParaViewModel(List<Materia> materias)
        {
            List<AlunoMateriasVM> materiasVmList = new List<AlunoMateriasVM>();

            foreach (Materia materia in materias)
            {
                AlunoMateriasVM materiasVM = new AlunoMateriasVM();
                materiasVM.NomeMateria = materia.NomeMateria;
                materiasVM.N1 = Convert.ToString(materia.Notas[0]);
                materiasVM.N2 = Convert.ToString(materia.Notas[1]);
                materiasVM.N3 = Convert.ToString(materia.Notas[2]);
                materiasVM.N4 = Convert.ToString(materia.Notas[3]);
                materiasVM.Media = Convert.ToString(materia.Media);
                materiasVM.Status = materia.Status;
                materiasVM.Ra_aluno = materia.Ra;
                materiasVmList.Add(materiasVM);
            }

            return materiasVmList;
        }

        public List<AlunoMateriasVM> ObterListaMateriaViewModelNomeMateria(List<Materia> materias)
        {
            List<AlunoMateriasVM> materiasVmList = new List<AlunoMateriasVM>();

            foreach (Materia materia in materias)
            {
                AlunoMateriasVM materiasVM = new AlunoMateriasVM();
                materiasVM.NomeMateria = materia.NomeMateria;
                materiasVmList.Add(materiasVM);
            }

            return materiasVmList;
        }
        #endregion

        #region CB MATEARIA

        public List<AlunoMateriasVM> ListaMateriasSomenteNome(AlunoMateriasVM dado)
        {
            try
            {
                List<Materia> materias = daoMateria.ObterListaMateriasSomenteNome();
                List<AlunoMateriasVM> materiasForVm = ObterListaMateriaViewModelNomeMateria(materias);
                List<AlunoMateriasVM> dadosCompletosList = new List<AlunoMateriasVM>();

                return ObterListaMateriasParaViewModel(materiasForVm, dadosCompletosList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region FILTRO BOLETIM

        public List<AlunoMateriasVM> ListaFiltrada(Filtros filtros)
        {
            try
            {
                List<Aluno> alunos = daoAluno.ObterListaFiltradaDeAlunos(filtros);
                List<Materia> materias = daoMateria.ObterListaMateriasNotasPorStatus(filtros);
                List<AlunoMateriasVM> alunosForVm = ObterListaAlunoParaViewModel(alunos);
                List<AlunoMateriasVM> materiasForVm = ObterListaMateriaParaViewModel(materias);
                List<AlunoMateriasVM> dadosCompletosList = new List<AlunoMateriasVM>();

                return ObterListaAlunosEMaterias(alunosForVm, materiasForVm, dadosCompletosList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        public List<AlunoMateriasVM> ListaBoletim()
        {
            try
            {
                List<Aluno> alunos = daoAluno.ObterListaAlunos();
                List<Materia> materias = daoMateria.ObterListaMateriasNotasComMedia();
                List<AlunoMateriasVM> alunosForVm = ObterListaAlunoParaViewModel(alunos);
                List<AlunoMateriasVM> materiasForVm = ObterListaMateriaParaViewModel(materias);
                List<AlunoMateriasVM> dadosCompletosList = new List<AlunoMateriasVM>();

                foreach (var aluno in alunos)
                {
                    var alunosCompletos = materiasForVm.Where(m => m.Ra_aluno == aluno.Ra && !string.IsNullOrEmpty(m.Media));

                    foreach (var materia in alunosCompletos)
                    {
                        var dadosCompletos = new AlunoMateriasVM(
                            aluno.Ra,
                            aluno.Nome,
                            aluno.Sala,
                            materia.NomeMateria,
                            materia.N1,
                            materia.N2,
                            materia.N3,
                            materia.N4,
                            materia.Media,
                            materia.Status
                        );

                        dadosCompletosList.Add(dadosCompletos);
                    }
                }

                return dadosCompletosList;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

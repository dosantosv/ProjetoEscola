using ProjetoWindowsForm.DAO;
using ProjetoWindowsForm.Entidades;
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

        #region FILTERS BOLETIM

        public List<AlunoMateriasVM> ListaFiltradaPorNome(AlunoMateriasVM aluno)
        {
            try
            {
                List<Aluno> alunos = daoAluno.ObterListaAlunoPorNome(aluno);
                List<Materia> materias = daoMateria.ObterListaMateriasNotasComMedia();
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

        public List<AlunoMateriasVM> ListaFiltradaPorRa(AlunoMateriasVM aluno)
        {
            try
            {
                List<Aluno> alunos = daoAluno.ObterListaAlunosPorRa(aluno);
                List<Materia> materias = daoMateria.ObterListaMateriasNotasComMedia();
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

        public List<AlunoMateriasVM> ListraFiltradaPorSala(AlunoMateriasVM aluno)
        {
            try
            {
                List<Aluno> alunos = daoAluno.ObterListaAlunoPorSala(aluno);
                List<Materia> materias = daoMateria.ObterListaMateriasNotasComMedia();
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

        public List<AlunoMateriasVM> ListaFiltradaPorStatus(AlunoMateriasVM aluno)
        {
            try
            {
                List<Aluno> alunos = daoAluno.ObterListaAlunos();
                List<Materia> materias = daoMateria.ObterListaMateriasNotasPorStatus(aluno);
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

        public List<AlunoMateriasVM> ListaFiltradaPorRaENome(AlunoMateriasVM aluno)
        {
            try
            {
                List<Aluno> alunos = daoAluno.ObterListaAlunoPorRaENome(aluno);
                List<Materia> materias = daoMateria.ObterListaMateriasNotasComMedia();
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


        public List<AlunoMateriasVM> ListaFiltradaPorRaEStatus(AlunoMateriasVM alunoMateria)
        {
            try
            {
                List<Aluno> alunos = daoAluno.ObterListaAlunosPorRa(alunoMateria);
                List<Materia> materias = daoMateria.ObterListaMateriasNotasPorStatus(alunoMateria);
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

        public List<AlunoMateriasVM> ListaFiltradaPorNomeEStatus(AlunoMateriasVM alunoMateria)
        {
            try
            {
                List<Aluno> alunos = daoAluno.ObterListaAlunoPorNome(alunoMateria);
                List<Materia> materias = daoMateria.ObterListaMateriasNotasPorStatus(alunoMateria);
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

        public List<AlunoMateriasVM> ListaFiltradaPorNomeESala(AlunoMateriasVM aluno)
        {
            try
            {
                List<Aluno> alunos = daoAluno.ObterListaAlunoPorNomeESala(aluno);
                List<Materia> materias = daoMateria.ObterListaMateriasNotasComMedia();
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

        public List<AlunoMateriasVM> ListaFiltradaPorSalaEStatus(AlunoMateriasVM alunoMateria)
        {
            try
            {
                List<Aluno> alunos = daoAluno.ObterListaAlunoPorSala(alunoMateria);
                List<Materia> materias = daoMateria.ObterListaMateriasNotasPorStatus(alunoMateria);
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

        public List<AlunoMateriasVM> ListaFiltradaPorRaNomeSalaEStatus(AlunoMateriasVM alunoMateria)
        {
            try
            {
                List<Aluno> alunos = daoAluno.ObterListaAlunoPorNomeSalaERa(alunoMateria);
                List<Materia> materias = daoMateria.ObterListaMateriasNotasPorStatus(alunoMateria);
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

        public List<AlunoMateriasVM> ListaFiltradaPorRaNomeEStatus(AlunoMateriasVM alunoMateria)
        {
            try
            {
                List<Aluno> alunos = daoAluno.ObterListaAlunoPorRaENome(alunoMateria);
                List<Materia> materias = daoMateria.ObterListaMateriasNotasPorStatus(alunoMateria);
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

        public List<AlunoMateriasVM> ListaFiltradaPorRaNomeESala(AlunoMateriasVM alunoMateria)
        {
            try
            {
                List<Aluno> alunos = daoAluno.ObterListaAlunoPorNomeSalaERa(alunoMateria);
                List<Materia> materias = daoMateria.ObterListaMateriasNotasComMedia();
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

        public List<AlunoMateriasVM> ListaFiltradaPorNomeStatusESala(AlunoMateriasVM alunoMateria)
        {
            try
            {
                List<Aluno> alunos = daoAluno.ObterListaAlunoPorNomeESala(alunoMateria);
                List<Materia> materias = daoMateria.ObterListaMateriasNotasPorStatus(alunoMateria);
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


    }
}

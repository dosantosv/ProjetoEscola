using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using ProjetoWindowsForm.DAO;
using ProjetoWindowsForm.Entidades;

namespace ProjetoWindowsForm.ViewModel
{
    public class AlunoProfessorVM
    {
        Conexao con = new Conexao();
        AlunoDAO daoAluno = new AlunoDAO();
        ProfessorDAO daoProfessor = new ProfessorDAO();
        MateriaDAO daoMateria = new MateriaDAO();

        #region ALUNO
        public int Ra { get; set; }
        public string Nome { get; set; }
        public string Sala { get; set; }
        #endregion

        #region PROFESSOR
        public string Id { get; set; }
        public string NomeProf { get; set; }
        public string TurmaProf { get; set; }
        public string Materia { get; set; }
        #endregion

        #region NOTAS_MATERIAS
        public string NomeMateria { get; set; }
        public string N1 { get; set; }
        public string N2 { get; set; }
        public string N3 { get; set; }
        public string N4 { get; set; }
        public string Media { get; set; }
        public string Status { get; set; }
        public int Ra_aluno { get; set; }
        #endregion

        public AlunoProfessorVM()
        {


        }

        public AlunoProfessorVM(int ra, string nome, string sala, string nomeMateria, string n1, string n2, string n3, string n4, string media, string status)
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

        public AlunoProfessorVM(string nomeMateria, string n1, string n2, string n3, string n4, string media, string status, int ra_aluno)
        {
            NomeMateria = nomeMateria;
            N1 = n1;
            N2 = n2;
            N3 = n3;
            N4 = n4;
            Media = media;
            Status = status;
            Ra_aluno = ra_aluno;
        }

        public AlunoProfessorVM(int ra, string nome, string sala, string id, string nomeProf, string turmaProf, string materia, string nomeMateria, string n1, string n2, string n3, string n4, string media, string status)
        {
            Ra = ra;
            Nome = nome;
            Sala = sala;
            Id = id;
            NomeProf = nomeProf;
            TurmaProf = turmaProf;
            Materia = materia;
            NomeMateria = nomeMateria;
            N1 = n1;
            N2 = n2;
            N3 = n3;
            N4 = n4;
            Media = media;
            Status = status;
            Status = status;
        }

        public AlunoProfessorVM(string materia)
        {
            Materia = materia;
        }

        public AlunoProfessorVM(int ra, string nome, string sala)
        {
            Ra = ra;
            Nome = nome;
            Sala = sala;
        }
        public AlunoProfessorVM(string id, string nomeProf, string turmaProf, string materia)
        {
            Id = id;
            NomeProf = nomeProf;
            TurmaProf = turmaProf;
            Materia = materia;
        }

        #region FOR VM
        public List<AlunoProfessorVM> GetListAlunoForVm(List<Aluno> alunos)
        {
            List<AlunoProfessorVM> alunoVMList = new List<AlunoProfessorVM>();

            foreach (Aluno aluno in alunos)
            {
                AlunoProfessorVM alunoMateriasVM = new AlunoProfessorVM();
                alunoMateriasVM.Ra = aluno.Ra;
                alunoMateriasVM.Nome = aluno.Nome;
                alunoMateriasVM.Sala = aluno.Sala;

                alunoVMList.Add(alunoMateriasVM);
            }

            return alunoVMList;
        }

        public List<AlunoProfessorVM> GetListMateriaForVm(List<Materia> materias)
        {
            List<AlunoProfessorVM> materiasVmList = new List<AlunoProfessorVM>();

            foreach (Materia materia in materias)
            {
                AlunoProfessorVM materiasVM = new AlunoProfessorVM();
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

        public List<AlunoProfessorVM> GetListProfessorForVm(List<Professor> professores)
        {
            List<AlunoProfessorVM> professoresVmList = new List<AlunoProfessorVM>();

            foreach (Professor professor in professores)
            {
                AlunoProfessorVM professorVM = new AlunoProfessorVM();
                professorVM.Id =  Convert.ToString(professor.Id);
                professorVM.NomeProf = professor.Nome;
                professorVM.TurmaProf = professor.Sala;
                professorVM.Materia = professor.Materia;
                professoresVmList.Add(professorVM);
            }

            return professoresVmList;
        }
        #endregion

        public List<AlunoProfessorVM> GetListAlunos(MySqlCommand sql)
        {
            MySqlDataAdapter da = new MySqlDataAdapter(sql);
            DataTable dt = new DataTable();
            da.Fill(dt);

            var alunos = new List<AlunoProfessorVM>();

            foreach (DataRow dr in dt.Rows)
            {
                var ra = Convert.ToInt32(dr["ra"]);
                var nome = Convert.ToString(dr["nome"]);
                var sala = Convert.ToString(dr["sala"]);
                alunos.Add(new AlunoProfessorVM(ra, nome, sala));
            }
            return alunos;
        }



        public List<AlunoProfessorVM> GetListMaterias(MySqlCommand sql)
        {
            MySqlDataAdapter da = new MySqlDataAdapter(sql);
            DataTable dt = new DataTable();
            da.Fill(dt);

            var materiasNotas = new List<AlunoProfessorVM>();

            foreach (DataRow dr in dt.Rows)
            {
                var materia = Convert.ToString(dr["materia"]);
                var n1 = Convert.ToString(dr["N1"]);
                var n2 = Convert.ToString(dr["N2"]);
                var n3 = Convert.ToString(dr["N3"]);
                var n4 = Convert.ToString(dr["N4"]);
                var media = Convert.ToString(dr["media"]);
                var status = Convert.ToString(dr["status"]);
                var ra_aluno = Convert.ToInt32(dr["ra_aluno"]);
                materiasNotas.Add(new AlunoProfessorVM(materia, n1, n2, n3, n4, media, status, ra_aluno));
            }
            return materiasNotas;
        }

        public List<AlunoProfessorVM> ListMedias()
        {
            try
            {
                List<Aluno> alunos = daoAluno.GetListAlunoPerSalaForGlobalVar();
                List<Professor> professores = daoProfessor.GetListProfessorPerMateriaForGlobalVar();
                List<Materia> materias = daoMateria.GetListMateriasAll();
                List<AlunoProfessorVM> alunosForVm = GetListAlunoForVm(alunos);
                List<AlunoProfessorVM> professoresForVm = GetListProfessorForVm(professores);
                List<AlunoProfessorVM> materiasForVm = GetListMateriaForVm(materias);
                List<AlunoProfessorVM> dadosCompletosList = new List<AlunoProfessorVM>();

                foreach (var aluno in alunosForVm)
                {
                    var professorCorrespondente = professoresForVm.FirstOrDefault(p => p.TurmaProf == aluno.Sala);

                    if (professorCorrespondente != null)
                    {
                        var materiaCorrespondente = materiasForVm.FirstOrDefault(m => m.Ra_aluno == aluno.Ra && m.NomeMateria == professorCorrespondente.Materia);

                        var dadosCompletos = new AlunoProfessorVM(
                            aluno.Ra,
                            aluno.Nome,
                            aluno.Sala,
                            professorCorrespondente.Id,
                            professorCorrespondente.NomeProf ?? "",
                            professorCorrespondente.TurmaProf ?? "",
                            professorCorrespondente.Materia,
                            materiaCorrespondente?.NomeMateria ?? "",
                            materiaCorrespondente?.N1 ?? "",
                            materiaCorrespondente?.N2 ?? "",
                            materiaCorrespondente?.N3 ?? "",
                            materiaCorrespondente?.N4 ?? "",
                            materiaCorrespondente?.Media ?? "",
                            materiaCorrespondente?.Status ?? ""
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


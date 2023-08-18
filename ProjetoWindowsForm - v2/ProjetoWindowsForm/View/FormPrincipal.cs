using System;
using System.Windows.Forms;
using System.Threading;
using ProjetoWindowsForm.View;
using ProjetoWindowsForm.Repository;

namespace ProjetoWindowsForm
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        public void Login()
        {
            if (Logado.Usuario == "admin")
            {
                LoginDiretoria();
            }
            else if( Logado.Senha == "123")
            {
                LoginDiretoria();
            }
            else if (Logado.Usuario != "admin")
            {
                LoginProfessor();
            }
        }

        public void LoginProfessor()
        {
            btnAlunos.Enabled = false;
            btnProfessores.Enabled = false;
            btnBoletim.Enabled = false;
            btnCalcularMedia.Enabled = true;
        }

        public void LoginDiretoria()
        {
            btnAlunos.Enabled = true;
            btnProfessores.Enabled = true;
            btnBoletim.Enabled = true;
            btnCalcularMedia.Enabled = false;
        }

        private void btnAlunos_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread alunos;
            alunos = new Thread(AbrirAlunos);
            alunos.SetApartmentState(ApartmentState.STA);
            alunos.Start();
            
        }

        private void btnProfessores_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread professores;
            professores = new Thread(AbrirProfessores);
            professores.SetApartmentState(ApartmentState.MTA);
            professores.Start();
            
        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread login;
            login = new Thread(abrirJanela);
            login.SetApartmentState(ApartmentState.MTA);
            login.Start();
            
        }
        private void AbrirAlunos()
        {
            Application.Run(new FormAluno());
        }

        private void btnCalcularMedia_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread calcular;
            calcular = new Thread(AbrirCalcular);
            calcular.SetApartmentState(ApartmentState.MTA);
            calcular.Start();
            
        }

        private void btnBoletim_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread boletim;
            boletim = new Thread(AbrirBoletim);
            boletim.SetApartmentState (ApartmentState.MTA);
            boletim.Start();
            
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            Login();
        }

        private void AbrirBoletim()
        {
            Application.Run(new FormBoletim());
        }

        private void AbrirCalcular()
        {
            Application.Run(new FormCalcularMedia());
        }

        private void AbrirProfessores()
        {
            Application.Run(new FormProfessor());
        }
        private void abrirJanela(object obj)
        {
            Application.Run(new FormLogin());
        }
    }
}

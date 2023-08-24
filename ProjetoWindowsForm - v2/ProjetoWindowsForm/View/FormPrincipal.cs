using System;
using System.Windows.Forms;
using System.Threading;
using ProjetoWindowsForm.View;
using ProjetoWindowsForm.Repository;
using ProjetoWindowsForm.Entidades;
using ProjetoWindowsForm.Model;

namespace ProjetoWindowsForm
{
    public partial class FormPrincipal : Form 
    {
        UsuarioModel model = new UsuarioModel();
        Diretoria diretoria = new Diretoria();
        public FormPrincipal()
        {

            InitializeComponent();
        }

        public void Login(Diretoria diretoria)
        {
             if (diretoria.Permissao == Logado.Permissao)
            {
                LoginDiretoria();
            }
            else
            {
                LoginProfessor();
            }
        }

        public void LoginProfessor()
        {
            btnAlunos.Click -= btnAlunos_Click;
            btnAlunos.Cursor = Cursors.No;
            btnProfessores.Click -= btnProfessores_Click;
            btnProfessores.Cursor = Cursors.No;
            btnBoletim.Click -= btnBoletim_Click;
            btnBoletim.Cursor = Cursors.No;
            btnCalcularMedia.Enabled = true;
            toolTip1.Active = false;
            toolTip2.Active = true;
            btnCalcularMedia.Cursor = Cursors.Hand;
        }


        public void LoginDiretoria()
        {
            btnAlunos.Cursor = Cursors.Hand;
            btnProfessores.Cursor = Cursors.Hand;
            btnBoletim.Cursor = Cursors.Hand;
            btnCalcularMedia.Cursor = Cursors.No;
            toolTip1.Active = true;
            toolTip2.Active = false;
            btnCalcularMedia.Click -= btnCalcularMedia_Click;
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
            Login(diretoria);
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

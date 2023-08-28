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

        public void LoginDiretoria(Diretoria diretoria)
        {
            try
            {
                if (diretoria.Permissao == Login.Permissao)
                {
                    LoginDiretoria();
                }
                else
                {
                    LoginProfessor();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void LoginProfessor()
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }


        public void LoginDiretoria()
        {
            try
            {
                btnAlunos.Cursor = Cursors.Hand;
                btnProfessores.Cursor = Cursors.Hand;
                btnBoletim.Cursor = Cursors.Hand;
                btnCalcularMedia.Cursor = Cursors.No;
                toolTip1.Active = true;
                toolTip2.Active = false;
                btnCalcularMedia.Click -= btnCalcularMedia_Click;
            }
            catch (Exception)
            {

                throw;
            }
        }

 

        private void btnAlunos_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                Thread alunos;
                alunos = new Thread(AbrirAlunos);
                alunos.SetApartmentState(ApartmentState.STA);
                alunos.Start();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnProfessores_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                Thread professores;
                professores = new Thread(AbrirProfessores);
                professores.SetApartmentState(ApartmentState.MTA);
                professores.Start();
            }
            catch (Exception)
            {

                throw;
            }  
        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                Thread login;
                login = new Thread(abrirJanela);
                login.SetApartmentState(ApartmentState.MTA);
                login.Start();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void AbrirAlunos()
        {
            try
            {
                Application.Run(new FormAluno());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCalcularMedia_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                Thread calcular;
                calcular = new Thread(AbrirCalcular);
                calcular.SetApartmentState(ApartmentState.MTA);
                calcular.Start();
            }
            catch (Exception)
            {

                throw;
            }   
        }

        private void btnBoletim_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                Thread boletim;
                boletim = new Thread(AbrirBoletim);
                boletim.SetApartmentState(ApartmentState.MTA);
                boletim.Start();
            }
            catch (Exception)
            {

                throw;
            }   
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                LoginDiretoria(diretoria);
            }
            catch (Exception)
            {

                throw;
            }
       }

        private void AbrirBoletim()
        {
            try
            {
                Application.Run(new FormBoletim());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AbrirCalcular()
        {
            try
            {
                Application.Run(new FormCalcularMedia());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AbrirProfessores()
        {
            try
            {
                Application.Run(new FormProfessor());
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void abrirJanela(object obj)
        {
            try
            {
                Application.Run(new FormLogin());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

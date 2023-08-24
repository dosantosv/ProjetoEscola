using System;
using System.Drawing;
using System.Windows.Forms;
using ProjetoWindowsForm.Model;
using ProjetoWindowsForm.Repository;
using ProjetoWindowsForm.Entidades;
using System.Threading;

namespace ProjetoWindowsForm
{
    public partial class FormLogin : Form
    {
        UsuarioModel model = new UsuarioModel();
        public FormLogin()
        {
            InitializeComponent();
        }

        public void Logar(Diretoria diretoria)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsuario.Text))
                {
                    MessageBox.Show("Preencha o Usuário");
                    txtUsuario.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtSenha.Text))
                {
                    MessageBox.Show("Preencha a Senha");
                    txtSenha.Focus();
                    return;
                }

                diretoria.Usuario = txtUsuario.Text;
                diretoria.Senha = txtSenha.Text;
                

                diretoria = model.Login(diretoria);

                if (diretoria.Usuario == null)
                {
                    lblMensagem.Text = "Usuário ou senha incorretos!!";
                    lblMensagem.ForeColor = Color.Red;
                    return;
                }

                FormPrincipal form = new FormPrincipal();
                this.Hide();
                form.Show();

                if (txtUsuario.Text == diretoria.Usuario)
                {
                    form.LoginDiretoria();
                } 
                else
                {
                    form.LoginProfessor();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Logar" + ex.Message);
            }
        }


        public void LogarProf(Professor professor)
        {
            try
            {

                professor.Usuario = txtUsuario.Text;
                professor.Senha = txtSenha.Text;

                professor = model.LoginProf(professor);

                if (string.IsNullOrEmpty(professor.Usuario))
                {
                    lblMensagem.Text = "Usuário ou senha incorretos!!";
                    lblMensagem.ForeColor = Color.Red;
                    return;
                }

                FormPrincipal form = new FormPrincipal();
                if (txtUsuario.Text == professor.Usuario)
                {
                    form.LoginProfessor();
                }
                else
                {
                    form.LoginDiretoria();
                }

                this.Hide();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Logar" + ex.Message);
            }
        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Diretoria usuario = new Diretoria();
            Professor usuarioProf = new Professor();
            Logar(usuario);
            LogarProf(usuarioProf);
        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread t1;
            t1 = new Thread(abrirJanela);
            t1.SetApartmentState(ApartmentState.MTA);
            t1.Start();
        }
        private void abrirJanela(object obj)
        {
            Application.Run(new FormLogin());
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

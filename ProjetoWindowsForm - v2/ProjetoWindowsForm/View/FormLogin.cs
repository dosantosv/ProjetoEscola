using System;
using System.Drawing;
using System.Windows.Forms;
using ProjetoWindowsForm.Model;
using ProjetoWindowsForm.Repository;
using ProjetoWindowsForm.Entidades;
using System.Threading;
using ProjetoWindowsForm.Entities;

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

                model.LoginDiretoria(diretoria);

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

                model.LoginProf(professor);

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
            try
            {
                Diretoria usuario = new Diretoria();
                Professor usuarioProf = new Professor();
                Logar(usuario);
                LogarProf(usuarioProf);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

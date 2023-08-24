using System;
using System.Windows.Forms;
using ProjetoWindowsForm.Model;
using ProjetoWindowsForm.Entidades;
using System.Threading;
using System.Collections.Generic;

namespace ProjetoWindowsForm.View

{
    public partial class FormAluno : Form
    {
        AlunoModel model = new AlunoModel();
        Aluno aluno = new Aluno();

        public FormAluno()
        {
            InitializeComponent();
        }

        public void ListarDados()
        {
            try
            {
                gridAlunos.AutoGenerateColumns = false;
                gridAlunos.DataSource = model.ObterListGeralAlunos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar os dados" + ex.Message);
            }
            
        }
        public void CadastrarAluno(Aluno aluno)
        {
            try
            {
                aluno.Nome = txtNome.Text;
                aluno.Nascimento = Convert.ToDateTime(dtNascimento.Text);
                aluno.Sala = cbSala.Text;
                aluno.Sexo = cbSexo.Text;
                
                if(string.IsNullOrEmpty(txtNome.Text))
                {
                    MessageBox.Show("O nome não pode estar vázio");
                    return;
                }

                if(!string.IsNullOrEmpty(txtRa.Text))
                {
                    MessageBox.Show("Esse aluno já existe, selecione Limpar e cadastre um novo aluno caso deseje!");
                    return;
                }

                if(string.IsNullOrEmpty(cbSala.Text))
                {
                    MessageBox.Show("Não é possível criar um aluno sem selecionar uma sala, crie primeiro um professor para depois criar um aluno!!");
                    return;
                }

                model.Cadastrar(aluno);
                MessageBox.Show("Aluno criado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar o aluno, preencha os campos corretamente!" + ex.Message);
            }
        }
        public void ExcluirAluno(Aluno aluno)
        {
            try
            {
                aluno.Ra = Convert.ToInt32(txtRa.Text);
                if (string.IsNullOrEmpty(txtRa.Text))
                {
                    MessageBox.Show("Para realizar uma exclusão você deve primeiro selecionar um aluno");
                }
                else
                {
                    model.Excluir(aluno);
                    MessageBox.Show("Aluno excluído com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir o aluno!" + ex.Message);
            }
        }

        public void EditarAluno(Aluno aluno)
        {
            try
            {
                aluno.Ra = Convert.ToInt32(txtRa.Text);
                aluno.Nome = txtNome.Text;
                aluno.Nascimento = Convert.ToDateTime(dtNascimento.Text);
                aluno.Sala = cbSala.Text;
                aluno.Sexo = cbSexo.Text;

                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    MessageBox.Show("Não existe nenhum aluno a ser editado!");
                    return;
                } else
                {
                    model.Editar(aluno);
                    MessageBox.Show("Aluno editado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar o aluno!" + ex.Message);
            }
        }
        public void LimparDados()
        {
            txtRa.Text = "";
            txtNome.Text = "";
            dtNascimento.Text = "";
            cbSala.Text = "";
        }
        private void SairLogin(object obj)
        {
            Application.Run(new FormLogin());
        }

        private void Voltar(object obj)
        {
            Application.Run(new FormPrincipal());
        }
        private void FormAluno_Load(object sender, EventArgs e)
        {
            List<Professor> professores = model.Listar<Professor>();
            List<string> salasUnicas = new List<string>();

            foreach (Professor professor in professores)
            {
                string sala = professor.Sala;

                if (!salasUnicas.Contains(sala))
                {
                    salasUnicas.Add(sala);
                }
            }
            cbSala.DataSource = salasUnicas;
            cbSala.DisplayMember = "sala";
            cbSexo.SelectedIndex = 0;
            ListarDados();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            CadastrarAluno(aluno);
            ListarDados();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRa.Text))
            {
                MessageBox.Show("Selecione na tabela um aluno para excluir!");
                return;
            }

            if (MessageBox.Show("Deseja mesmo excluir o Aluno?", "Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            ExcluirAluno(aluno);
            ListarDados();
            LimparDados();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparDados();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRa.Text))
            {
                MessageBox.Show("Selecione na tabela um aluno para editar");
                return;
            }

            if (MessageBox.Show("Deseja mesmo editar o Aluno?", "Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            EditarAluno(aluno);
            ListarDados();
            LimparDados();
        }

        private void gridAlunos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRa.Text = gridAlunos.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = gridAlunos.CurrentRow.Cells[1].Value.ToString();
            dtNascimento.Value = Convert.ToDateTime(gridAlunos.CurrentRow.Cells[2].Value);
            cbSala.Text = gridAlunos.CurrentRow.Cells[3].Value.ToString();
            cbSexo.Text = gridAlunos.CurrentRow.Cells[4].Value.ToString();
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
            if (textBox.Text.Length >= 80 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void cbSala_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbSexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread sair;
            sair = new Thread(SairLogin);
            sair.SetApartmentState(ApartmentState.MTA);
            sair.Start();
        }

        private void menuVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread voltar;
            voltar = new Thread(Voltar);
            voltar.SetApartmentState(ApartmentState.MTA);
            voltar.Start();
        }
    }
}

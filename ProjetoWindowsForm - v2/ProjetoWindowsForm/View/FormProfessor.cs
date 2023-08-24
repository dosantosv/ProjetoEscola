using ProjetoWindowsForm.Model;
using System;
using System.Windows.Forms;
using ProjetoWindowsForm.Entidades;
using System.Threading;
using ProjetoWindowsForm.ViewModel;

namespace ProjetoWindowsForm
{
    public partial class FormProfessor : Form
    {
        ProfessorModel model = new ProfessorModel();
        Professor professor = new Professor();
        Diretoria diretoria = new Diretoria();  
        TurmaModel turmaModel = new TurmaModel();
        AlunoMateriasVM viewModel = new AlunoMateriasVM();
        public FormProfessor()
        {
            InitializeComponent();
        }

        public void ListarDados()
        {
            try
            {
                gridProfessores.AutoGenerateColumns = false;
                gridProfessores.DataSource = model.Listar<Professor>();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao listar os dados" + ex.Message);
            }

        }

        public void CadastrarProfessor(Professor professor, Diretoria diretoria)
        {
            try
            {
                professor.Nome = txtNome.Text;
                professor.Nascimento = Convert.ToDateTime(dtNascimento.Text);
                professor.Sala = cbSala.Text;
                professor.Materia = cbMateria.Text;
                professor.Sexo = cbSexo.Text;
                professor.Usuario = txtUsuario.Text;
                professor.Senha = txtSenha.Text;

                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    MessageBox.Show("O nome não pode ser vázio");
                    return;
                } 

                if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtSenha.Text))
                {
                    MessageBox.Show("Você deve digitar todas as informações de usuário!");
                    return;
                }

                if (txtUsuario.Text == diretoria.Permissao)
                {
                    MessageBox.Show("Impossível criar um usuário de professor como ADMIN!");
                    return;
                }

                if (!string.IsNullOrEmpty(txtId.Text))
                {
                    MessageBox.Show("Esse professor já existe, selecione Limpar e cadastre um novo professor caso deseje!");
                    return;
                }

                model.Cadastrar(professor);
                MessageBox.Show("Professor criado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar o professor, preencha os campos corretamente!" + ex.Message);
            }
        }

        public void ExcluirProfessor(Professor professor)
        {
            try
            {
                professor.Id = Convert.ToInt32(txtId.Text);
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    MessageBox.Show("Para realizar uma exclusão você deve primeiro selecionar um Professor");
                }
                else
                {
                    model.Excluir(professor);
                    MessageBox.Show("Professor excluído com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir o Professor!" + ex.Message);
            }
        }

        public void EditarProfessor(Professor professor)
        {
            try
            {
                professor.Id = Convert.ToInt32(txtId.Text);
                professor.Nome = txtNome.Text;
                professor.Nascimento = Convert.ToDateTime(dtNascimento.Text);
                professor.Sala = cbSala.Text;
                professor.Materia = cbMateria.Text;  
                professor.Sexo = cbSexo.Text;
                professor.Usuario = txtUsuario.Text;
                professor.Senha = txtSenha.Text;

                if (string.IsNullOrEmpty(txtId.Text))
                {
                    MessageBox.Show("Não existe nenhum Professor a ser editado!");
                    return;
                }
                else
                {
                    model.Editar(professor);
                    MessageBox.Show("Professor editado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar o Professor!" + ex.Message);
            }
        }

        public void LimparDados()
        {
            txtId.Text = "";
            txtNome.Text = "";
            dtNascimento.Text = "";
            txtUsuario.Text = "";
            txtSenha.Text = "";
        }


        private void FormProfessor_Load(object sender, EventArgs e)
        {
            cbSala.DataSource = turmaModel.Listar();
            cbMateria.DataSource = viewModel.ListaMateriasSomenteNome(viewModel);
            cbMateria.DisplayMember = "NomeMateria";
            cbSala.DisplayMember = "Sala";
            cbSexo.SelectedIndex = 0;
            ListarDados();
        }
        
        private void btnCadastrarProf_Click(object sender, EventArgs e)
        {
            CadastrarProfessor(professor, diretoria);
            ListarDados();
            LimparDados();
        }

        private void gridProfessores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = gridProfessores.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = gridProfessores.CurrentRow.Cells[1].Value.ToString();
            dtNascimento.Value = Convert.ToDateTime(gridProfessores.CurrentRow.Cells[2].Value);
            cbSala.Text = gridProfessores.CurrentRow.Cells[3].Value.ToString();
            cbSexo.Text = gridProfessores.CurrentRow.Cells[4].Value.ToString();
            cbMateria.Text = gridProfessores.CurrentRow.Cells[5].Value.ToString();
            txtUsuario.Text = gridProfessores.CurrentRow.Cells[6].Value.ToString();
            txtSenha.Text = gridProfessores.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnEditarProf_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Selecione na tabela um professor para editar");
                return;
            }

            if (MessageBox.Show("Deseja mesmo Editar o Professor?", "Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            EditarProfessor(professor);
            ListarDados();
            LimparDados();
        }

        private void btnExcluirProf_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Selecione na tabela um Professor para excluir!");
                return;
            }

            if (MessageBox.Show("Deseja mesmo excluir o Professor?", "Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            ExcluirProfessor(professor);
            ListarDados();
            LimparDados();
        }
        private void SairLogin(object obj)
        {
            Application.Run(new FormLogin());
        }

        private void Voltar(object obj)
        {
            Application.Run(new FormPrincipal());
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparDados();
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

        private void cbMateria_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread t1;
            t1 = new Thread(SairLogin);
            t1.SetApartmentState(ApartmentState.MTA);
            t1.Start();
        }

        private void menuVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread t2;
            t2 = new Thread(Voltar);
            t2.SetApartmentState(ApartmentState.MTA);
            t2.Start();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}

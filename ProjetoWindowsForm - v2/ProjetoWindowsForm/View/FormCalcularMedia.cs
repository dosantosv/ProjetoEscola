using System;
using System.Windows.Forms;
using ProjetoWindowsForm.Model;
using ProjetoWindowsForm.Entidades;
using System.Threading;
using ProjetoWindowsForm.ViewModel;
using ProjetoWindowsForm.Service;

namespace ProjetoWindowsForm.View
{
    public partial class FormCalcularMedia : Form
    {
        Materia dado = new Materia();
        AlunoProfessorVM viewModel = new AlunoProfessorVM();
        MateriaModel materiaModel = new MateriaModel();
        Professor professor = new Professor();
        CalcularMedia service = new CalcularMedia();

        public FormCalcularMedia()
        {
            InitializeComponent();
        }
        public void ObterNotaMedia(Materia notas, AlunoProfessorVM dados)
        {
            try
            {

                service.ObterNotasEStatusMateria(notas);

                lblMedia.Text = $"{notas.Media:F2}";
                txtN1.Text = $"{notas.Notas[0]:F2}";
                txtN2.Text = $"{notas.Notas[1]:F2}";
                txtN3.Text = $"{notas.Notas[2]:F2}";
                txtN4.Text = $"{notas.Notas[3]:F2}";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CalcularMedia(Materia dado, AlunoProfessorVM dados)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRa.Text))
                {
                    MessageBox.Show("Selecione um Aluno para calcular a média");
                    LimparDados();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtN1.Text) || string.IsNullOrWhiteSpace(txtN2.Text) ||
                    string.IsNullOrWhiteSpace(txtN3.Text) || string.IsNullOrWhiteSpace(txtN4.Text))
                {
                    MessageBox.Show("Você precisa digitar as 4 notas.");
                    return;
                }
                dado.NomeMateria = Convert.ToString(lblMateriaAluno.Text);
                dado.Notas[0] = Convert.ToDecimal(txtN1.Text);
                dado.Notas[1] = Convert.ToDecimal(txtN2.Text);
                dado.Notas[2] = Convert.ToDecimal(txtN3.Text);
                dado.Notas[3] = Convert.ToDecimal(txtN4.Text);
                dados.Ra = Convert.ToInt32(txtRa.Text);
                dados.Id = Convert.ToString(txtId.Text);
                dados.Ra = Convert.ToInt32(txtRa.Text);


                if (dado.Notas[0] < 0 || dado.Notas[0] > 10 || dado.Notas[1] < 0 || dado.Notas[1] > 10 || dado.Notas[2] < 0 || dado.Notas[2] > 10 || dado.Notas[3] < 0 || dado.Notas[3] > 10)
                {
                    MessageBox.Show("As notas precisam ser de 0 a 10!");
                    LimparDados();
                    return;
                }


                ObterNotaMedia(dado, dados);

                materiaModel.CadastrarNotas(dado, dados);
                MessageBox.Show("Notas Calculadas com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao calcular a média " + ex.Message);
            }
        }

        public void EditarNotas(Materia dado, AlunoProfessorVM dados)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRa.Text))
                {
                    MessageBox.Show("Selecione um Aluno para calcular a média");
                    LimparDados();
                    return;
                }

                if (string.IsNullOrEmpty(txtN1.Text) || string.IsNullOrEmpty(txtN2.Text) ||
                    string.IsNullOrEmpty(txtN3.Text) || string.IsNullOrEmpty(txtN4.Text))
                {
                    MessageBox.Show("Digite as 4 notas por favor!");
                }

                dado.Notas[0] = Convert.ToDecimal(txtN1.Text);
                dado.Notas[1] = Convert.ToDecimal(txtN2.Text);
                dado.Notas[2] = Convert.ToDecimal(txtN3.Text);
                dado.Notas[3] = Convert.ToDecimal(txtN4.Text);
                dado.Media = Convert.ToDecimal(lblMedia.Text);
                dados.Ra = Convert.ToInt32(txtRa.Text);

                if (dado.Notas[0] < 0 || dado.Notas[0] > 10 || dado.Notas[1] < 0 || dado.Notas[1] > 10 || dado.Notas[2] < 0 || dado.Notas[2] > 10 || dado.Notas[3] < 0 || dado.Notas[3] > 10)
                {
                    MessageBox.Show("As notas precisam ser de 0 a 10!");
                    LimparDados();
                    return;
                }

                ObterNotaMedia(dado, dados);



                materiaModel.EditarNotas(dado, dados);
                MessageBox.Show("Notas editadas com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar as notas " + ex.Message);
            }
        }

        public void DeletarNotas(AlunoProfessorVM dados)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRa.Text))
                {
                    MessageBox.Show("Selecione um Aluno para calcular a média");
                    LimparDados();
                    return;
                }
                dados.Ra = Convert.ToInt32(txtRa.Text);
                materiaModel.DeletarNotas(dados);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir as notas " + ex.Message);
            }
        }

        public void ListarDados()
        {
            try
            {
                gridMedias.AutoGenerateColumns = false;
                gridMedias.DataSource = viewModel.ListMedias(professor);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void FormCalcularMedia_Load(object sender, EventArgs e)
        {
            try
            {
                ListarDados();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void LimparDados()
        {
            try
            {
                txtRa.Text = "";
                txtId.Text = "";
                lblNomeAluno.Text = "";
                lblTurmaAluno.Text = "";
                lblMateriaAluno.Text = "";
                lblNomeProf.Text = "";
                lblTurmaProf.Text = "";
                lblMateriaProf.Text = "";
                txtN1.Text = "";
                txtN2.Text = "";
                txtN3.Text = "";
                txtN4.Text = "";
                lblMedia.Text = "";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void VerificarValoresDigitados(object sender, KeyPressEventArgs e)
        {
            try
            {
                TextBox textBox = (TextBox)sender;

                if (Char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == (char)8)
                {
                    if (textBox.Text.Length < 4 || e.KeyChar == (char)8)
                    {
                        if (e.KeyChar == ',' && textBox.Text.Contains(","))
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = false;

                            if (e.KeyChar == ',' && textBox.Text.Length == 0)
                            {
                                textBox.Text = "0,";
                                textBox.SelectionStart = textBox.Text.Length;
                            }
                        }
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void gridMedias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRa.Text = gridMedias.CurrentRow.Cells[0].Value.ToString();
            lblNomeAluno.Text = gridMedias.CurrentRow.Cells[1].Value.ToString();
            lblTurmaAluno.Text = gridMedias.CurrentRow.Cells[2].Value.ToString();
            lblMateriaAluno.Text = gridMedias.CurrentRow.Cells[6].Value.ToString();
            txtId.Text = gridMedias.CurrentRow.Cells[3].Value.ToString();
            lblNomeProf.Text = gridMedias.CurrentRow.Cells[4].Value.ToString();
            lblTurmaProf.Text = gridMedias.CurrentRow.Cells[5].Value.ToString();
            lblMateriaProf.Text = gridMedias.CurrentRow.Cells[6].Value.ToString();
            txtN1.Text = gridMedias.CurrentRow.Cells[8].Value.ToString();
            txtN2.Text = gridMedias.CurrentRow.Cells[9].Value.ToString();
            txtN3.Text = gridMedias.CurrentRow.Cells[10].Value.ToString();
            txtN4.Text = gridMedias.CurrentRow.Cells[11].Value.ToString();
            lblMedia.Text = gridMedias.CurrentRow.Cells[12].Value.ToString();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRa.Text))
                {
                    MessageBox.Show("Selecione na tabela um aluno para assim poder calcular suas notas!");
                    return;
                }

                if (!string.IsNullOrEmpty(lblMedia.Text))
                {
                    MessageBox.Show("Impossível calcular novamente a nota desse aluno, caso queira editar, selecione a opção EDITAR!");
                    return;
                }

                CalcularMedia(dado, viewModel);
                ListarDados();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRa.Text))
                {
                    MessageBox.Show("Selecione na tabela um aluno para assim poder editar suas notas!");
                    return;
                }

                EditarNotas(dado, viewModel);
                ListarDados();
                LimparDados();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRa.Text))
                {
                    MessageBox.Show("Selecione na tabela um aluno para assim poder excluir suas notas!");
                    return;
                }

                if (MessageBox.Show("Deseja mesmo excluir as notas?", "Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
                DeletarNotas(viewModel);
                ListarDados();
                LimparDados();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SairLogin(object obj)
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

        private void Voltar(object obj)
        {
            try
            {
                Application.Run(new FormPrincipal());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                Thread t2;
                t2 = new Thread(Voltar);
                t2.SetApartmentState(ApartmentState.MTA);
                t2.Start();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtN1_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerificarValoresDigitados(sender, e);
        }

        private void txtN2_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerificarValoresDigitados(sender, e);
        }

        private void txtN3_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerificarValoresDigitados(sender, e);
        }

        private void txtN4_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerificarValoresDigitados(sender, e);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                Thread t1;
                t1 = new Thread(SairLogin);
                t1.SetApartmentState(ApartmentState.MTA);
                t1.Start();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

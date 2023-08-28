using System;
using System.Windows.Forms;
using System.Threading;
using ProjetoWindowsForm.ViewModel;

namespace ProjetoWindowsForm.View
{
    public partial class FormBoletim : Form
    {
        AlunoMateriasVM viewModel = new AlunoMateriasVM();
        public FormBoletim()
        {
            InitializeComponent();
        }

        public void ListarDados()
        {
            try
            {
                gridBoletim.AutoGenerateColumns = false;
                gridBoletim.DataSource = viewModel.ListaBoletim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar os dados " + ex.Message);
            }
        }

        public void Filter(AlunoMateriasVM dado)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRa.Text) &&
                    string.IsNullOrWhiteSpace(txtNome.Text) &&
                    cbStatus.Text == "Todos" &&
                    cbSala.Text == "Todos")
                {
                    ListarDados();
                    return;
                }


                if (!string.IsNullOrWhiteSpace(txtRa.Text) &&
                    string.IsNullOrWhiteSpace(txtNome.Text) &&
                    cbStatus.Text == "Todos" &&
                    cbSala.Text == "Todos")
                {
                    dado.Ra = Convert.ToInt64(txtRa.Text);
                    gridBoletim.DataSource = viewModel.ListaFiltradaPorRa(dado);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRa.Text) &&
                    !string.IsNullOrWhiteSpace(txtNome.Text) &&
                    cbStatus.Text == "Todos" &&
                    cbSala.Text == "Todos")
                {
                    dado.Nome = txtNome.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltradaPorNome(dado);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRa.Text) &&
                    string.IsNullOrWhiteSpace(txtNome.Text) &&
                    !(cbStatus.Text == "Todos") &&
                    cbSala.Text == "Todos")
                {
                    dado.Status = cbStatus.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltradaPorStatus(dado);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRa.Text) &&
                    string.IsNullOrWhiteSpace(txtNome.Text) &&
                    cbStatus.Text == "Todos" &&
                    !(cbSala.Text == "Todos"))
                {
                    dado.Sala = cbSala.Text;
                    gridBoletim.DataSource = viewModel.ListraFiltradaPorSala(dado);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtRa.Text) &&
                    !string.IsNullOrWhiteSpace(txtNome.Text) &&
                    cbStatus.Text == "Todos" &&
                    cbSala.Text == "Todos")
                {
                    dado.Ra = Convert.ToInt64(txtRa.Text);
                    dado.Nome = txtNome.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltradaPorRaENome(dado);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtRa.Text) &&
                    string.IsNullOrWhiteSpace(txtNome.Text) &&
                    !(cbStatus.Text == "Todos") &&
                    cbSala.Text == "Todos")
                {
                    dado.Ra = Convert.ToInt64(txtRa.Text);
                    dado.Status = cbStatus.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltradaPorRaEStatus(dado);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRa.Text) &&
                    !string.IsNullOrWhiteSpace(txtNome.Text) &&
                    !(cbStatus.Text == "Todos") &&
                    cbSala.Text == "Todos")
                {
                    dado.Nome = txtNome.Text;
                    dado.Status = cbStatus.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltradaPorNomeEStatus(dado);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRa.Text) &&
                    !string.IsNullOrWhiteSpace(txtNome.Text) &&
                    cbStatus.Text == "Todos" &&
                    !(cbSala.Text == "Todos"))
                {
                    dado.Nome = txtNome.Text;
                    dado.Sala = cbSala.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltradaPorNomeESala(dado);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRa.Text) &&
                    string.IsNullOrWhiteSpace(txtNome.Text) &&
                    !(cbStatus.Text == "Todos") &&
                    !(cbSala.Text == "Todos"))
                {
                    dado.Status = cbStatus.Text;
                    dado.Sala = cbSala.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltradaPorSalaEStatus(dado);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtRa.Text) &&
                    !string.IsNullOrWhiteSpace(txtNome.Text) &&
                    !(cbStatus.Text == "Todos") &&
                    !(cbSala.Text == "Todos"))
                {
                    dado.Ra = Convert.ToInt64(txtRa.Text);
                    dado.Nome = txtNome.Text;
                    dado.Status = cbStatus.Text;
                    dado.Sala = cbSala.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltradaPorRaNomeSalaEStatus(dado);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtRa.Text) &&
                    !string.IsNullOrWhiteSpace(txtNome.Text) &&
                    !(cbStatus.Text == "Todos") &&
                    (cbSala.Text == "Todos"))
                {
                    dado.Ra = Convert.ToInt64(txtRa.Text);
                    dado.Nome = txtNome.Text;
                    dado.Status = cbStatus.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltradaPorRaNomeEStatus(dado);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtRa.Text) &&
                    !string.IsNullOrWhiteSpace(txtNome.Text) &&
                    (cbStatus.Text == "Todos") &&
                    !(cbSala.Text == "Todos"))
                {
                    dado.Ra = Convert.ToInt64(txtRa.Text);
                    dado.Nome = txtNome.Text;
                    dado.Sala = cbSala.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltradaPorRaNomeESala(dado);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRa.Text) &&
                    !string.IsNullOrWhiteSpace(txtNome.Text) &&
                    !(cbStatus.Text == "Todos") &&
                    !(cbSala.Text == "Todos"))
                {
                    dado.Nome = txtNome.Text;
                    dado.Status = cbStatus.Text;
                    dado.Sala = cbSala.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltradaPorNomeStatusESala(dado);
                    return;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                cbSala.SelectedIndex = 0;
                cbStatus.SelectedIndex = 0;
                ListarDados();
            }
            catch (Exception)
            {

                throw;
            }
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

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Filter(viewModel);

                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    ListarDados();
                    return;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtRa_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(txtRa.Text))
                {
                    ListarDados();
                }
                else
                {
                    Filter(viewModel);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void cbStatus_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbStatus.Text == "Todos")
                {
                    ListarDados();
                }
                else
                {
                    Filter(viewModel);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cbSala_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbSala.SelectedIndex == 0)
                {
                    ListarDados();
                }
                else
                {
                    Filter(viewModel);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtRa_KeyPress(object sender, KeyPressEventArgs e)
       {
            try
            {
                TextBox textBox = (TextBox)sender;

                if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (textBox.Text.Length >= 9 && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        private void cbStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '\b')
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {

                throw;
            }        
        }

        private void cbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cbSala_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '\b')
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void cbSala_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    e.SuppressKeyPress = true;
                }
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

    }
}

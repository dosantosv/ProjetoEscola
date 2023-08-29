using System;
using System.Windows.Forms;
using System.Threading;
using ProjetoWindowsForm.ViewModel;
using ProjetoWindowsForm.Entities;

namespace ProjetoWindowsForm.View
{
    public partial class FormBoletim : Form
    {
        AlunoMateriasVM viewModel = new AlunoMateriasVM();
        Filtros filtros = new Filtros();
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

        public void Filter(Filtros filtros)
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
                    filtros.Ra = Convert.ToInt64(txtRa.Text);
                    gridBoletim.DataSource = viewModel.ListaFiltrada(filtros);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRa.Text) &&
                    !string.IsNullOrWhiteSpace(txtNome.Text) &&
                    cbStatus.Text == "Todos" &&
                    cbSala.Text == "Todos")
                {
                    filtros.Nome = txtNome.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltrada(filtros);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRa.Text) &&
                    string.IsNullOrWhiteSpace(txtNome.Text) &&
                    !(cbStatus.Text == "Todos") &&
                    cbSala.Text == "Todos")
                {
                    filtros.Status = cbStatus.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltrada(filtros);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRa.Text) &&
                    string.IsNullOrWhiteSpace(txtNome.Text) &&
                    cbStatus.Text == "Todos" &&
                    !(cbSala.Text == "Todos"))
                {
                    filtros.Sala = cbSala.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltrada(filtros);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtRa.Text) &&
                    !string.IsNullOrWhiteSpace(txtNome.Text) &&
                    cbStatus.Text == "Todos" &&
                    cbSala.Text == "Todos")
                {
                    filtros.Ra = Convert.ToInt64(txtRa.Text);
                    filtros.Nome = txtNome.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltrada(filtros);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtRa.Text) &&
                    string.IsNullOrWhiteSpace(txtNome.Text) &&
                    !(cbStatus.Text == "Todos") &&
                    cbSala.Text == "Todos")
                {
                    filtros.Ra = Convert.ToInt64(txtRa.Text);
                    filtros.Status = cbStatus.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltrada(filtros);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRa.Text) &&
                    !string.IsNullOrWhiteSpace(txtNome.Text) &&
                    !(cbStatus.Text == "Todos") &&
                    cbSala.Text == "Todos")
                {
                    filtros.Nome = txtNome.Text;
                    filtros.Status = cbStatus.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltrada(filtros);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRa.Text) &&
                    !string.IsNullOrWhiteSpace(txtNome.Text) &&
                    cbStatus.Text == "Todos" &&
                    !(cbSala.Text == "Todos"))
                {
                    filtros.Nome = txtNome.Text;
                    filtros.Sala = cbSala.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltrada(filtros);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRa.Text) &&
                    string.IsNullOrWhiteSpace(txtNome.Text) &&
                    !(cbStatus.Text == "Todos") &&
                    !(cbSala.Text == "Todos"))
                {
                    filtros.Status = cbStatus.Text;
                    filtros.Sala = cbSala.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltrada(filtros);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtRa.Text) &&
                    !string.IsNullOrWhiteSpace(txtNome.Text) &&
                    !(cbStatus.Text == "Todos") &&
                    !(cbSala.Text == "Todos"))
                {
                    filtros.Ra = Convert.ToInt64(txtRa.Text);
                    filtros.Nome = txtNome.Text;
                    filtros.Status = cbStatus.Text;
                    filtros.Sala = cbSala.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltrada(filtros);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtRa.Text) &&
                    !string.IsNullOrWhiteSpace(txtNome.Text) &&
                    !(cbStatus.Text == "Todos") &&
                    (cbSala.Text == "Todos"))
                {
                    filtros.Ra = Convert.ToInt64(txtRa.Text);
                    filtros.Nome = txtNome.Text;
                    filtros.Status = cbStatus.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltrada(filtros);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtRa.Text) &&
                    !string.IsNullOrWhiteSpace(txtNome.Text) &&
                    (cbStatus.Text == "Todos") &&
                    !(cbSala.Text == "Todos"))
                {
                    filtros.Ra = Convert.ToInt64(txtRa.Text);
                    filtros.Nome = txtNome.Text;
                    filtros.Sala = cbSala.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltrada(filtros);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRa.Text) &&
                    !string.IsNullOrWhiteSpace(txtNome.Text) &&
                    !(cbStatus.Text == "Todos") &&
                    !(cbSala.Text == "Todos"))
                {
                    filtros.Nome = txtNome.Text;
                    filtros.Status = cbStatus.Text;
                    filtros.Sala = cbSala.Text;
                    gridBoletim.DataSource = viewModel.ListaFiltrada(filtros);
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
                Filter(filtros);

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
                    Filter(filtros);
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
                    Filter(filtros);
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
                    Filter(filtros);
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

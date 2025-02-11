using BiBliotekarz.Class;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class ShowClientsForm : Form
    {
        public ShowClientsForm()
        {
            InitializeComponent();
        }

        private void ShowClientsForm_Load(object sender, EventArgs e)
        {
            LoadClients();
        }

        private void LoadClients()
        {
            
            var clients = LibraryManager.GetClients();
            if (clients.Count == 0)
            {
                MessageBox.Show("Brak klientów w bazie danych.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            clientsDataGridView.DataSource = clients.Select(c => new
            {
                c.ClientID, 
                c.Name,
                c.Surname,
                c.PESEL,
                c.TelephoneNumber,
                c.HomeAddress
            }).ToList();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (clientsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz klienta do usunięcia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clientId = (int)clientsDataGridView.SelectedRows[0].Cells["ClientID"].Value;

            try
            {
                LibraryManager.DeleteClient(clientId); 
                MessageBox.Show("Klient został usunięty.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadClients(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas usuwania klienta: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (clientsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz klienta do edycji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clientId = (int)clientsDataGridView.SelectedRows[0].Cells["ClientID"].Value;

            try
            {
                var client = LibraryManager.GetClientById(clientId);
                var editForm = new EditClientForm(client); 
                editForm.ShowDialog();
                LoadClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas edycji klienta: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}

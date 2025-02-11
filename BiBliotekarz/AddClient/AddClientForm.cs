using BiBliotekarz.Class;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class AddClientForm : Form
    {
        public AddClientForm()
        {
            InitializeComponent();
        }

        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            // Pobieranie danych z pól tekstowych
            string name = txtName.Text.Trim();
            string surname = txtSurname.Text.Trim();
            string pesel = txtPESEL.Text.Trim();
            string telephone = txtTelephone.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) ||
                string.IsNullOrWhiteSpace(pesel) || pesel.Length != 11 || !pesel.All(char.IsDigit))
            {
                MessageBox.Show("Wprowadź poprawne dane. PESEL musi mieć 11 cyfr.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrWhiteSpace(telephone) && telephone.Length != 9)
            {
                MessageBox.Show("Numer telefonu musi mieć 9 cyfr lub być pusty.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tworzenie obiektu klienta
            var client = new Client(name, surname, pesel, telephone, address);

            try
            {
                LibraryManager.AddClient(client); // Dodanie klienta do bazy danych
                MessageBox.Show("Klient został dodany.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Zamknięcie formularza po zapisaniu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}

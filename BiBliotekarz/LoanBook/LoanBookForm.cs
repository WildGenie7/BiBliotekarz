using BiBliotekarz.Class;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class LoanBookForm : Form
    {
        public LoanBookForm()
        {
            InitializeComponent();
        }

        private void LoanBookForm_Load(object sender, EventArgs e)
        {
            try
            {
          
                var clients = LibraryManager.GetClients()
                    .Select(client => new
                    {
                        client.ClientID,
                        DisplayName = $"{client.Name} {client.Surname}",
                        client.PESEL 
                    })
                    .ToList();

                clientComboBox.DataSource = clients;
                clientComboBox.DisplayMember = "DisplayName"; 
                clientComboBox.ValueMember = "ClientID";      

                var books = LibraryManager.GetBooks()
                    .Select(book => new { book.BookID, book.BookName })
                    .ToList();

                bookComboBox.DataSource = books;
                bookComboBox.DisplayMember = "BookName";  
                bookComboBox.ValueMember = "BookID";      
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClientComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clientComboBox.SelectedItem is not null)
            {
                var selectedClient = (dynamic)clientComboBox.SelectedItem; 
                peselTextBox.Text = selectedClient.PESEL; 
            }
        }

        private void BtnLoanBook_Click(object sender, EventArgs e)
        {
            if (clientComboBox.SelectedItem == null || bookComboBox.SelectedItem == null)
            {
                MessageBox.Show("Wybierz klienta i książkę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int clientId = Convert.ToInt32(clientComboBox.SelectedValue); 
                long bookId = Convert.ToInt64(bookComboBox.SelectedValue);  
                DateTime loanDate = DateTime.Now;

                LibraryManager.AddTransaction(clientId, bookId, loanDate);

                MessageBox.Show("Książka została wypożyczona!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas wypożyczania książki: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

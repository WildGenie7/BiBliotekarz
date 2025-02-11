using BiBliotekarz.Class;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class ReturnBookForm : Form
    {
        private int? selectedClientId;

        public ReturnBookForm()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = true;

            InitializeComponent();
            this.btnSearchClient.Click += BtnSearchClient_Click;
            this.btnReturnBook.Click += BtnReturnBook_Click;
        }

        private void BtnSearchClient_Click(object sender, EventArgs e)
        {
            string pesel = txtPesel.Text.Trim();

            if (string.IsNullOrWhiteSpace(pesel))
            {
                MessageBox.Show("Wprowadź PESEL.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            var client = LibraryManager.GetClients().FirstOrDefault(c => c.PESEL == pesel);

            if (client == null)
            {
                MessageBox.Show("Nie znaleziono klienta o podanym PESEL.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                borrowedBooksGridView.DataSource = null;
                selectedClientId = null;
                return;
            }

            selectedClientId = client.ClientID;
            lblClientInfo.Text = $"{client.Name} {client.Surname}"; 
            LoadBorrowedBooks(client.ClientID);
        }

        private void LoadBorrowedBooks(int clientId)
        {
            var transactions = LibraryManager.GetActiveTransactions()
                .Where(t => t.ClientID == clientId)
                .Select(t => new
                {
                    t.TransactionID,
                    BookTitle = LibraryManager.GetBookById(t.BookID)?.BookName ?? "Nieznana książka",
                    t.LoanDate,
                    DueDate = t.LoanDate.AddDays(30),
                    Fine = CalculateFine(t.LoanDate)
                })
                .ToList();

            borrowedBooksGridView.DataSource = transactions;

            if (!transactions.Any())
            {
                MessageBox.Show("Wybrany klient nie ma wypożyczonych książek.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private decimal CalculateFine(DateTime loanDate)
        {
            var overdueDays = (DateTime.Now - loanDate.AddDays(30)).Days;
            return overdueDays > 0 ? overdueDays * 2m : 0m; // 2 zł za każdy dzień spóźnienia
        }

        private void BtnReturnBook_Click(object sender, EventArgs e)
        {
            if (borrowedBooksGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz książkę do zwrotu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!selectedClientId.HasValue)
            {
                MessageBox.Show("Najpierw wyszukaj klienta po PESEL.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedTransactionId = (int)borrowedBooksGridView.SelectedRows[0].Cells["TransactionID"].Value;
            DateTime returnDate = DateTime.Now;

            try
            {
                LibraryManager.ReturnBook(selectedTransactionId, returnDate);
                MessageBox.Show("Książka została zwrócona!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBorrowedBooks(selectedClientId.Value); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

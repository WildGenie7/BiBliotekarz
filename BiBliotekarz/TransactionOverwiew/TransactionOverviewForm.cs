using BiBliotekarz.Class;
using System;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class TransactionOverviewForm : Form
    {
        public TransactionOverviewForm()
        {
            InitializeComponent();
        }

        private void TransactionOverviewForm_Load(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void LoadTransactions()
        {
            try
            {
                var transactions = LibraryManager.GetAllTransactions();

                if (transactions.Count == 0)
                {
                    MessageBox.Show("Brak transakcji do wyświetlenia.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                transactionsDataGridView.DataSource = transactions; 
                transactionsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Dopasuj kolumny
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania transakcji: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

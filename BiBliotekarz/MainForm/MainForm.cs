using BiBliotekarz.Class;
using System;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnManageBooks_Click(object sender, EventArgs e)
        {
            var bookForm = new BookManagementForm();
            bookForm.ShowDialog();
        }

        private void btnShowBooks_Click(object sender, EventArgs e)
        {
            var showBooksForm = new ShowBooksForm();
            showBooksForm.ShowDialog();
        }
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            var addClientForm = new AddClientForm();
            addClientForm.ShowDialog();
        }

        private void btnShowClients_Click(object sender, EventArgs e)
        {
            var showClientsForm = new ShowClientsForm();
            showClientsForm.ShowDialog();
        }

        private void BtnLoanBook_Click(object sender, EventArgs e)
        {
            var loanBookForm = new LoanBookForm();
            loanBookForm.ShowDialog();
        }

        private void BtnReturnBook_Click(object sender, EventArgs e)
        {
            var returnBookForm = new ReturnBookForm();
            returnBookForm.ShowDialog();
        }

        private void BtnViewTransactions_Click(object sender, EventArgs e)
        {
            var transactionForm = new TransactionOverviewForm();
            transactionForm.ShowDialog();
        }
        private void BtnExportMenu_Click(object sender, EventArgs e)
        {
            ExportDataForm exportForm = new ExportDataForm();
            exportForm.ShowDialog();
        }


    }
}

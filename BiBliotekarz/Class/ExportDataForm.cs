using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using OfficeOpenXml;

namespace BiBliotekarz.Class
{
    public partial class ExportDataForm : Form
    {
        public ExportDataForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "Eksport danych";
            ClientSize = new System.Drawing.Size(300, 200);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            var btnExportBooks = new Button
            {
                Text = "Eksportuj książki",
                Location = new System.Drawing.Point(50, 30),
                Size = new System.Drawing.Size(200, 40)
            };
            btnExportBooks.Click += BtnExportBooks_Click;

            var btnExportClients = new Button
            {
                Text = "Eksportuj czytelników",
                Location = new System.Drawing.Point(50, 80),
                Size = new System.Drawing.Size(200, 40)
            };
            btnExportClients.Click += BtnExportClients_Click;

            var btnExportTransactions = new Button
            {
                Text = "Eksportuj transakcje",
                Location = new System.Drawing.Point(50, 130),
                Size = new System.Drawing.Size(200, 40)
            };
            btnExportTransactions.Click += BtnExportTransactions_Click;

            Controls.Add(btnExportBooks);
            Controls.Add(btnExportClients);
            Controls.Add(btnExportTransactions);
        }

        private void BtnExportBooks_Click(object sender, EventArgs e)
        {
            ExportToExcel("Books");
        }

        private void BtnExportClients_Click(object sender, EventArgs e)
        {
            ExportToExcel("Clients");
        }

        private void BtnExportTransactions_Click(object sender, EventArgs e)
        {
            ExportToExcel("Transactions");
        }

        private void ExportToExcel(string tableName)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                Title = $"Eksport {tableName}"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LibraryManager.ExportTableToExcel(tableName, saveFileDialog.FileName);
                    MessageBox.Show($"{tableName} zostały wyeksportowane.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

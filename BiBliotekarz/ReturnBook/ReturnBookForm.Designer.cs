using System.Windows.Forms;

namespace LibraryApp
{
    partial class ReturnBookForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtPesel;
        private Button btnSearchClient;
        private DataGridView borrowedBooksGridView;
        private Button btnReturnBook;
        private Label lblClientInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtPesel = new TextBox();
            btnSearchClient = new Button();
            borrowedBooksGridView = new DataGridView();
            btnReturnBook = new Button();
            lblClientInfo = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)borrowedBooksGridView).BeginInit();
            SuspendLayout();
            // 
            // txtPesel
            // 
            txtPesel.Location = new System.Drawing.Point(30, 38);
            txtPesel.Name = "txtPesel";
            txtPesel.PlaceholderText = "Wprowadź PESEL";
            txtPesel.Size = new System.Drawing.Size(200, 23);
            txtPesel.TabIndex = 0;
            // 
            // btnSearchClient
            // 
            btnSearchClient.Location = new System.Drawing.Point(236, 37);
            btnSearchClient.Name = "btnSearchClient";
            btnSearchClient.Size = new System.Drawing.Size(100, 23);
            btnSearchClient.TabIndex = 1;
            btnSearchClient.Text = "Szukaj";
            btnSearchClient.UseVisualStyleBackColor = true;
            // 
            // borrowedBooksGridView
            // 
            borrowedBooksGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            borrowedBooksGridView.Location = new System.Drawing.Point(30, 102);
            borrowedBooksGridView.Name = "borrowedBooksGridView";
            borrowedBooksGridView.ReadOnly = true;
            borrowedBooksGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            borrowedBooksGridView.Size = new System.Drawing.Size(500, 200);
            borrowedBooksGridView.TabIndex = 3;
            // 
            // btnReturnBook
            // 
            btnReturnBook.Location = new System.Drawing.Point(30, 308);
            btnReturnBook.Name = "btnReturnBook";
            btnReturnBook.Size = new System.Drawing.Size(200, 30);
            btnReturnBook.TabIndex = 4;
            btnReturnBook.Text = "Zwróć wybraną książkę";
            btnReturnBook.UseVisualStyleBackColor = true;
            // 
            // lblClientInfo
            // 
            lblClientInfo.Location = new System.Drawing.Point(30, 79);
            lblClientInfo.Name = "lblClientInfo";
            lblClientInfo.Size = new System.Drawing.Size(320, 20);
            lblClientInfo.TabIndex = 2;
            lblClientInfo.Text = "Informacje o kliencie";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(30, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(148, 15);
            label1.TabIndex = 5;
            label1.Text = "Wprowadź pesel czytelnika";
            // 
            // ReturnBookForm
            // 
            ClientSize = new System.Drawing.Size(600, 350);
            Controls.Add(label1);
            Controls.Add(txtPesel);
            Controls.Add(btnSearchClient);
            Controls.Add(lblClientInfo);
            Controls.Add(borrowedBooksGridView);
            Controls.Add(btnReturnBook);
            Name = "ReturnBookForm";
            Text = "Zwrot książki";
            ((System.ComponentModel.ISupportInitialize)borrowedBooksGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
    }
}

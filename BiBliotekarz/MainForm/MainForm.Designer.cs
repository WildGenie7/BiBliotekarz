using System.Windows.Forms;
using System;
using System.Drawing;

namespace LibraryApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnManageBooks;
        private Button btnShowBooks;
        private Button btnAddClient;
        private Button btnShowClients;
        private Button btnLoanBook;
        private Button btnReturnBook;
        private Button btnViewTransactions; // Deklaracja przycisku
        private Button btnExportMenu;


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
            btnExportMenu = new Button();
            btnLoanBook = new Button();
            btnReturnBook = new Button();
            btnManageBooks = new Button();
            btnShowBooks = new Button();
            btnAddClient = new Button();
            btnShowClients = new Button();
            btnViewTransactions = new Button();
            SuspendLayout();
            // 
            // btnExportMenu
            // 
            btnExportMenu.Location = new Point(0, 182);
            btnExportMenu.Name = "btnExportMenu";
            btnExportMenu.Size = new Size(200, 40);
            btnExportMenu.TabIndex = 0;
            btnExportMenu.Text = "Eksportuj dane";
            btnExportMenu.Click += BtnExportMenu_Click;
            // 
            // btnLoanBook
            // 
            btnLoanBook.Location = new Point(0, 126);
            btnLoanBook.Name = "btnLoanBook";
            btnLoanBook.Size = new Size(200, 40);
            btnLoanBook.TabIndex = 1;
            btnLoanBook.Text = "Wypożycz Książkę";
            btnLoanBook.UseVisualStyleBackColor = true;
            btnLoanBook.Click += BtnLoanBook_Click;
            // 
            // btnReturnBook
            // 
            btnReturnBook.Location = new Point(206, 126);
            btnReturnBook.Name = "btnReturnBook";
            btnReturnBook.Size = new Size(200, 40);
            btnReturnBook.TabIndex = 2;
            btnReturnBook.Text = "Zwróć Książkę";
            btnReturnBook.UseVisualStyleBackColor = true;
            btnReturnBook.Click += BtnReturnBook_Click;
            // 
            // btnManageBooks
            // 
            btnManageBooks.Location = new Point(0, 12);
            btnManageBooks.Name = "btnManageBooks";
            btnManageBooks.Size = new Size(200, 40);
            btnManageBooks.TabIndex = 0;
            btnManageBooks.Text = "Dodaj Książkę";
            btnManageBooks.UseVisualStyleBackColor = true;
            btnManageBooks.Click += btnManageBooks_Click;
            // 
            // btnShowBooks
            // 
            btnShowBooks.Location = new Point(206, 12);
            btnShowBooks.Name = "btnShowBooks";
            btnShowBooks.Size = new Size(200, 40);
            btnShowBooks.TabIndex = 1;
            btnShowBooks.Text = "Pokaż Książki";
            btnShowBooks.UseVisualStyleBackColor = true;
            btnShowBooks.Click += btnShowBooks_Click;
            // 
            // btnAddClient
            // 
            btnAddClient.Location = new Point(0, 68);
            btnAddClient.Name = "btnAddClient";
            btnAddClient.Size = new Size(200, 40);
            btnAddClient.TabIndex = 2;
            btnAddClient.Text = "Dodaj Czytelnika";
            btnAddClient.UseVisualStyleBackColor = true;
            btnAddClient.Click += btnAddClient_Click;
            // 
            // btnShowClients
            // 
            btnShowClients.Location = new Point(206, 68);
            btnShowClients.Name = "btnShowClients";
            btnShowClients.Size = new Size(200, 40);
            btnShowClients.TabIndex = 3;
            btnShowClients.Text = "Pokaż Czytelników";
            btnShowClients.UseVisualStyleBackColor = true;
            btnShowClients.Click += btnShowClients_Click;
            // 
            // btnViewTransactions
            // 
            btnViewTransactions.Location = new Point(206, 182);
            btnViewTransactions.Name = "btnViewTransactions";
            btnViewTransactions.Size = new Size(200, 40);
            btnViewTransactions.TabIndex = 4;
            btnViewTransactions.Text = "Przegląd Transakcji";
            btnViewTransactions.UseVisualStyleBackColor = true;
            btnViewTransactions.Click += BtnViewTransactions_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 261);
            Controls.Add(btnExportMenu);
            Controls.Add(btnManageBooks);
            Controls.Add(btnShowBooks);
            Controls.Add(btnAddClient);
            Controls.Add(btnShowClients);
            Controls.Add(btnLoanBook);
            Controls.Add(btnReturnBook);
            Controls.Add(btnViewTransactions);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "BiBliotekarz";
            ResumeLayout(false);
        }
    }
}

using System;
using System.Windows.Forms;

namespace LibraryApp
{
    partial class LoanBookForm
    {
       
        private System.ComponentModel.IContainer components = null;

        private ComboBox clientComboBox;
        private ComboBox bookComboBox;
        private TextBox peselTextBox;
        private Button btnLoanBook;

       
        
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
            clientComboBox = new ComboBox();
            bookComboBox = new ComboBox();
            peselTextBox = new TextBox();
            btnLoanBook = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            
            clientComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            clientComboBox.Location = new System.Drawing.Point(50, 30);
            clientComboBox.Name = "clientComboBox";
            clientComboBox.Size = new System.Drawing.Size(200, 23);
            clientComboBox.TabIndex = 0;
            clientComboBox.SelectedIndexChanged += ClientComboBox_SelectedIndexChanged;
            
            bookComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            bookComboBox.Location = new System.Drawing.Point(52, 95);
            bookComboBox.Name = "bookComboBox";
            bookComboBox.Size = new System.Drawing.Size(200, 23);
            bookComboBox.TabIndex = 2;
            
            peselTextBox.Location = new System.Drawing.Point(270, 30);
            peselTextBox.Name = "peselTextBox";
            peselTextBox.ReadOnly = true;
            peselTextBox.Size = new System.Drawing.Size(150, 23);
            peselTextBox.TabIndex = 1;
            
            btnLoanBook.Location = new System.Drawing.Point(50, 135);
            btnLoanBook.Name = "btnLoanBook";
            btnLoanBook.Size = new System.Drawing.Size(200, 30);
            btnLoanBook.TabIndex = 3;
            btnLoanBook.Text = "Wypożycz";
            btnLoanBook.UseVisualStyleBackColor = true;
            btnLoanBook.Click += BtnLoanBook_Click;
            
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(52, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(142, 15);
            label1.TabIndex = 4;
            label1.Text = "Imię i nazwisko czytelnika";
            
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(270, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(160, 15);
            label2.TabIndex = 5;
            label2.Text = "Sprawdź czy pesel się zgadza!";
            
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(52, 77);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(79, 15);
            label3.TabIndex = 6;
            label3.Text = "Nazwa książki";
            label3.Click += label3_Click;
            
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(450, 191);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(clientComboBox);
            Controls.Add(peselTextBox);
            Controls.Add(bookComboBox);
            Controls.Add(btnLoanBook);
            Name = "LoanBookForm";
            Text = "Wypożycz Książkę";
            Load += LoanBookForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
    }
}

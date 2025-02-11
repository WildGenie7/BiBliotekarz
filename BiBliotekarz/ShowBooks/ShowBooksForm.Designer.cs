using System;
using System.Windows.Forms;

namespace LibraryApp
{
    partial class ShowBooksForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView booksDataGridView;
        private Button deleteButton;
        private Button editButton;

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
            booksDataGridView = new DataGridView();
            deleteButton = new Button();
            editButton = new Button();
            ((System.ComponentModel.ISupportInitialize)booksDataGridView).BeginInit();
            SuspendLayout();
            // 
            // booksDataGridView
            // 
            booksDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            booksDataGridView.Location = new System.Drawing.Point(12, 12);
            booksDataGridView.MultiSelect = false;
            booksDataGridView.Name = "booksDataGridView";
            booksDataGridView.ReadOnly = true;
            booksDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            booksDataGridView.Size = new System.Drawing.Size(846, 400);
            booksDataGridView.TabIndex = 0;
            // 
            // deleteButton
            // 
            deleteButton.Location = new System.Drawing.Point(12, 420);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new System.Drawing.Size(100, 30);
            deleteButton.TabIndex = 1;
            deleteButton.Text = "Usuń";
            deleteButton.Click += DeleteButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new System.Drawing.Point(120, 420);
            editButton.Name = "editButton";
            editButton.Size = new System.Drawing.Size(100, 30);
            editButton.TabIndex = 2;
            editButton.Text = "Edytuj";
            editButton.Click += EditButton_Click;
            // 
            // ShowBooksForm
            // 
            ClientSize = new System.Drawing.Size(870, 460);
            Controls.Add(booksDataGridView);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ShowBooksForm";
            Text = "Lista Książek";
            Load += ShowBooksForm_Load;
            ((System.ComponentModel.ISupportInitialize)booksDataGridView).EndInit();
            ResumeLayout(false);
        }
    }
}

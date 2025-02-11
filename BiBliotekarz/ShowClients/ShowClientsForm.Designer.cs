using System.Windows.Forms;

namespace LibraryApp
{
    partial class ShowClientsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView clientsDataGridView;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;

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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; // Ustaw styl ramki
            this.MaximizeBox = false; // Wyłącz przycisk maksymalizacji
            this.MinimizeBox = true; // Opcjonalnie, zostaw przycisk minimalizacji

            this.clientsDataGridView = new System.Windows.Forms.DataGridView();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // clientsDataGridView
            // 
            this.clientsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.clientsDataGridView.Size = new System.Drawing.Size(760, 400);
            this.clientsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.clientsDataGridView.MultiSelect = false;
            this.clientsDataGridView.ReadOnly = true;
            this.clientsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 
            // deleteButton
            // 
            this.deleteButton.Text = "Usuń";
            this.deleteButton.Location = new System.Drawing.Point(12, 420);
            this.deleteButton.Size = new System.Drawing.Size(100, 30);
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);

            // 
            // editButton
            // 
            this.editButton.Text = "Edytuj";
            this.editButton.Location = new System.Drawing.Point(120, 420);
            this.editButton.Size = new System.Drawing.Size(100, 30);
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);

            // 
            // ShowClientsForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.clientsDataGridView);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Text = "Lista Czytleników";
            this.Load += new System.EventHandler(this.ShowClientsForm_Load);
            this.ResumeLayout(false);
        }
    }
}

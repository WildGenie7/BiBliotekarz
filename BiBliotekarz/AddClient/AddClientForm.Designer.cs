namespace LibraryApp
{
    partial class AddClientForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label lblPESEL;
        private System.Windows.Forms.TextBox txtPESEL;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSaveClient;

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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblSurname = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.lblPESEL = new System.Windows.Forms.Label();
            this.txtPESEL = new System.Windows.Forms.TextBox();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnSaveClient = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Name = "lblName";
            this.lblName.Text = "Imię";

            // txtName
            this.txtName.Location = new System.Drawing.Point(150, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 23);

            // lblSurname
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(20, 60);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Text = "Nazwisko";

            // txtSurname
            this.txtSurname.Location = new System.Drawing.Point(150, 60);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(200, 23);

            // lblPESEL
            this.lblPESEL.AutoSize = true;
            this.lblPESEL.Location = new System.Drawing.Point(20, 100);
            this.lblPESEL.Name = "lblPESEL";
            this.lblPESEL.Text = "PESEL";

            // txtPESEL
            this.txtPESEL.Location = new System.Drawing.Point(150, 100);
            this.txtPESEL.Name = "txtPESEL";
            this.txtPESEL.Size = new System.Drawing.Size(200, 23);

            // lblTelephone
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Location = new System.Drawing.Point(20, 140);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Text = "Telefon";

            // txtTelephone
            this.txtTelephone.Location = new System.Drawing.Point(150, 140);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(200, 23);

            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(20, 180);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Text = "Adres";

            // txtAddress
            this.txtAddress.Location = new System.Drawing.Point(150, 180);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 23);

            // btnSaveClient
            this.btnSaveClient.Location = new System.Drawing.Point(150, 220);
            this.btnSaveClient.Name = "btnSaveClient";
            this.btnSaveClient.Size = new System.Drawing.Size(100, 30);
            this.btnSaveClient.Text = "Zapisz";
            this.btnSaveClient.Click += new System.EventHandler(this.btnSaveClient_Click);

            // AddClientForm
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.lblPESEL);
            this.Controls.Add(this.txtPESEL);
            this.Controls.Add(this.lblTelephone);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnSaveClient);
            this.Text = "Dodaj Czytelnika";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

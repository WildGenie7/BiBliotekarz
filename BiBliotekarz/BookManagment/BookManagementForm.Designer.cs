// BookManagementForm.Designer.cs
namespace LibraryApp
{
    partial class BookManagementForm
    {
        private System.ComponentModel.IContainer components = null;

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
            BookNameText = new System.Windows.Forms.Label();
            BookNameTextBox = new System.Windows.Forms.TextBox();
            AutorText = new System.Windows.Forms.Label();
            AutorTextBox = new System.Windows.Forms.TextBox();
            RelaseDateBox = new System.Windows.Forms.TextBox();
            RelaseDateText = new System.Windows.Forms.Label();
            BookCountText = new System.Windows.Forms.Label();
            BookCountBox = new System.Windows.Forms.TextBox();
            IdBookBox = new System.Windows.Forms.TextBox();
            IdBookText = new System.Windows.Forms.Label();
            SaveButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // BookNameText
            // 
            BookNameText.AutoSize = true;
            BookNameText.Location = new System.Drawing.Point(20, 24);
            BookNameText.Name = "BookNameText";
            BookNameText.Size = new System.Drawing.Size(80, 15);
            BookNameText.TabIndex = 0;
            BookNameText.Text = "Nazwa Książki";
            // 
            // BookNameTextBox
            // 
            BookNameTextBox.Location = new System.Drawing.Point(168, 21);
            BookNameTextBox.Name = "BookNameTextBox";
            BookNameTextBox.Size = new System.Drawing.Size(100, 23);
            BookNameTextBox.TabIndex = 1;
            // 
            // AutorText
            // 
            AutorText.AutoSize = true;
            AutorText.Location = new System.Drawing.Point(20, 58);
            AutorText.Name = "AutorText";
            AutorText.Size = new System.Drawing.Size(37, 15);
            AutorText.TabIndex = 2;
            AutorText.Text = "Autor";
            // 
            // AutorTextBox
            // 
            AutorTextBox.Location = new System.Drawing.Point(168, 58);
            AutorTextBox.Name = "AutorTextBox";
            AutorTextBox.Size = new System.Drawing.Size(100, 23);
            AutorTextBox.TabIndex = 3;
            // 
            // RelaseDateBox
            // 
            RelaseDateBox.Location = new System.Drawing.Point(168, 89);
            RelaseDateBox.Name = "RelaseDateBox";
            RelaseDateBox.Size = new System.Drawing.Size(100, 23);
            RelaseDateBox.TabIndex = 4;
            // 
            // RelaseDateText
            // 
            RelaseDateText.AutoSize = true;
            RelaseDateText.Location = new System.Drawing.Point(20, 89);
            RelaseDateText.Name = "RelaseDateText";
            RelaseDateText.Size = new System.Drawing.Size(80, 15);
            RelaseDateText.TabIndex = 5;
            RelaseDateText.Text = "Data Wydania";
            // 
            // BookCountText
            // 
            BookCountText.AutoSize = true;
            BookCountText.Location = new System.Drawing.Point(20, 120);
            BookCountText.Name = "BookCountText";
            BookCountText.Size = new System.Drawing.Size(109, 15);
            BookCountText.TabIndex = 6;
            BookCountText.Text = "Liczba Egzemplarzy";
            // 
            // BookCountBox
            // 
            BookCountBox.Location = new System.Drawing.Point(168, 120);
            BookCountBox.Name = "BookCountBox";
            BookCountBox.Size = new System.Drawing.Size(100, 23);
            BookCountBox.TabIndex = 7;
            // 
            // IdBookBox
            // 
            IdBookBox.Location = new System.Drawing.Point(168, 149);
            IdBookBox.Name = "IdBookBox";
            IdBookBox.Size = new System.Drawing.Size(100, 23);
            IdBookBox.TabIndex = 8;
            // 
            // IdBookText
            // 
            IdBookText.AutoSize = true;
            IdBookText.Location = new System.Drawing.Point(20, 147);
            IdBookText.Name = "IdBookText";
            IdBookText.Size = new System.Drawing.Size(56, 15);
            IdBookText.TabIndex = 9;
            IdBookText.Text = "ID Ksiązki";
            // 
            // SaveButton
            // 
            SaveButton.Location = new System.Drawing.Point(151, 217);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new System.Drawing.Size(75, 23);
            SaveButton.TabIndex = 10;
            SaveButton.Text = "Zapisz";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(287, 92);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(83, 15);
            label1.TabIndex = 11;
            label1.Text = "YYYY-MM-DD";
            // 
            // BookManagementForm
            // 
            ClientSize = new System.Drawing.Size(400, 251);
            Controls.Add(label1);
            Controls.Add(SaveButton);
            Controls.Add(IdBookText);
            Controls.Add(IdBookBox);
            Controls.Add(BookCountBox);
            Controls.Add(BookCountText);
            Controls.Add(RelaseDateText);
            Controls.Add(RelaseDateBox);
            Controls.Add(AutorTextBox);
            Controls.Add(AutorText);
            Controls.Add(BookNameTextBox);
            Controls.Add(BookNameText);
            Name = "BookManagementForm";
            Text = "Dodaj Książkę";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label BookNameText;
        private System.Windows.Forms.TextBox BookNameTextBox;
        private System.Windows.Forms.Label AutorText;
        private System.Windows.Forms.TextBox AutorTextBox;
        private System.Windows.Forms.TextBox RelaseDateBox;
        private System.Windows.Forms.Label RelaseDateText;
        private System.Windows.Forms.Label BookCountText;
        private System.Windows.Forms.TextBox BookCountBox;
        private System.Windows.Forms.TextBox IdBookBox;
        private System.Windows.Forms.Label IdBookText;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label label1;
    }
}


using System.Windows.Forms;

namespace LibraryApp
{
    partial class TransactionOverviewForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView transactionsDataGridView;

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

            this.transactionsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDataGridView)).BeginInit();
            this.SuspendLayout();

            // transactionsDataGridView
            this.transactionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transactionsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.transactionsDataGridView.Name = "transactionsDataGridView";
            this.transactionsDataGridView.Size = new System.Drawing.Size(760, 400);
            this.transactionsDataGridView.TabIndex = 0;

            // TransactionOverviewForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.transactionsDataGridView);
            this.Name = "TransactionOverviewForm";
            this.Text = "Przegląd Transakcji";
            this.Load += new System.EventHandler(this.TransactionOverviewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDataGridView)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

using LibraryApp;
using System;
using System.Windows.Forms;

namespace BiBliotekarz.Class
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            if (DatabaseManager.TestConnection())
            {
                MessageBox.Show("Po³¹czono z baz¹ danych LibraryDB.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nie uda³o siê po³¹czyæ z baz¹ danych LibraryDB.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new MainForm());
        }
    }
}

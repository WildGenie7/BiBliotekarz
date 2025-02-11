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
                MessageBox.Show("Po��czono z baz� danych LibraryDB.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nie uda�o si� po��czy� z baz� danych LibraryDB.", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new MainForm());
        }
    }
}

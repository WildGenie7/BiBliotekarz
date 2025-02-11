using BiBliotekarz.Class;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class ShowBooksForm : Form
    {
        public ShowBooksForm()
        {
            InitializeComponent();

        }

        private void ShowBooksForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void LoadBooks()
        {
            var books = LibraryManager.GetBooks(); 
            if (books.Count == 0)
            {
                MessageBox.Show("Brak książek w bazie danych.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

          
            booksDataGridView.DataSource = books.Select(b => new
            {
                b.BookID,
                b.BookName,
                b.Author,
                ReleaseDate = b.ReleaseDate.ToString("yyyy-MM-dd"),
                b.NumberOfBooks,
                b.AvailableBooks
            }).ToList();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (booksDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać książkę do usunięcia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = booksDataGridView.SelectedRows[0];
            long bookID = (long)selectedRow.Cells["BookID"].Value;

            try
            {
                LibraryManager.DeleteBook(bookID);
                MessageBox.Show("Książka została usunięta.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBooks(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas usuwania książki: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (booksDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać książkę do edycji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = booksDataGridView.SelectedRows[0];
            long bookID = (long)selectedRow.Cells["BookID"].Value; 

            var book = LibraryManager.GetBookById(bookID); 
                                                           
            var editForm = new EditBookForm(book); 
            editForm.ShowDialog();
            LoadBooks(); 
        }

    }
}
